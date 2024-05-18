using Fingrid.Api;
using Fingrid.Datasets;
using Fingrid.Model;
using FingridLogger.Helpers;
using FingridLogger.Settings;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Npgsql;

namespace FingridLogger;

public class HistoryForecastLogger(
    ILogger<HistoryForecastLogger> logger,
    IOptions<AppSettings> appSettings,
    IOptions<TimescaleDbSettings> timescaleDbSettings,
    IDataApi dataApi)
{
    private readonly AppSettings _appSettings = appSettings.Value;
    private readonly TimescaleDbSettings _timescaleDbSettings = timescaleDbSettings.Value;

    public async Task RunAsync(CancellationToken cancellationToken = default)
    {
        logger.LogInformation("Starting {LoggerName} with initial delay of {DelayMs} ms", nameof(HistoryForecastLogger), _appSettings.HistoryForecastInitialDelay);

        await Task.Delay(_appSettings.HistoryForecastInitialDelay, cancellationToken: cancellationToken);
        
        while (!cancellationToken.IsCancellationRequested)
        {
            try
            {
                // Create a CancellationToken that gets canceled after a timeout period
                using var cts =
                    cancellationToken.ExtendWithDelayedToken(TimeSpan.FromMilliseconds(_appSettings.Timeout));

                var loopStartTime = DateTime.UtcNow;

                // Fetch the latest time series data
                var dataSets =
                    $"{(int)History.Wind},{(int)Forecast.Consumption},{(int)Forecast.Production},{(int)Forecast.WindHourly},{(int)Forecast.WindDaily}";
                var startTime = DateTime.UtcNow.AddDays(-1);
                var multipleTimeseriesData = await dataApi.GetMultipleTimeseriesDataAsync(dataSets, startTime,
                    pageSize: 20000, cancellationToken: cts.Token);
                var data = multipleTimeseriesData.GetIWithPaginationTimeseriesDataOrTimeseriesDataOneRowPerTimePeriod()
                    .Data;
                await WriteHistoryAndForecastEntriesToTimescaleDb(data, cancellationToken);

                var loopEndTime = DateTime.UtcNow;
                var loopDuration = loopEndTime - loopStartTime;
                var delay = TimeSpan.FromMilliseconds(_appSettings.HistoryForecastLoggingInterval) - loopDuration;

                if (delay.TotalMilliseconds < 0)
                {
                    delay = TimeSpan.Zero;
                }

                logger.LogInformation("Next fetch with {LoggerName} at {DateTime} which is in {Delay}", nameof(HistoryForecastLogger), DateTimeOffset.UtcNow + delay,
                    delay.ToReadableString());
                await Task.Delay(delay, cancellationToken: cancellationToken);
            }
            catch (Exception ex)
            {
                logger.LogError(ex,
                    "Error occurred executing {LoggerName}", nameof(HistoryForecastLogger));
            }
        }
    }

    private async Task WriteHistoryAndForecastEntriesToTimescaleDb(
        List<IWithPaginationTimeseriesDataOrTimeseriesDataOneRowPerTimePeriodDataInner>? entries,
        CancellationToken cancellationToken = default)
    {
        try
        {
            if (_timescaleDbSettings.Enabled && entries != null)
            {
                try
                {
                    await using var conn = new NpgsqlConnection(_timescaleDbSettings.ConnectionString);
                    await conn.OpenAsync(cancellationToken);

                    foreach (var entry in entries)
                    {
                        var sql = $@"
                            INSERT INTO {_timescaleDbSettings.TimeSeriesTableName} (time, dataset_id, start_time, end_time, value)
                            VALUES (@time, @dataset_id, @start_time, @end_time, @value)
                            ON CONFLICT (time, dataset_id)
                            DO UPDATE SET
                                start_time = @start_time, end_time = @end_time, value = @value
                        ";

                        await using var cmd = new NpgsqlCommand(sql, conn);
                        var timeSeriesData = entry.GetTimeseriesData();
                        timeSeriesData.AddMetrics(cmd.Parameters);

                        await cmd.ExecuteNonQueryAsync(cancellationToken);
                    }
                }
                catch (Exception ex)
                {
                    logger.LogError(ex, "Error writing to TimescaleDB");
                }
            }
        }
        catch (Exception ex)
        {
            logger.LogWarning(ex, "Unknown error while saving data to TimescaleDB");
        }
    }
}