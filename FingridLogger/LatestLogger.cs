using Fingrid.Api;
using Fingrid.Datasets;
using Fingrid.Model;
using FingridLogger.Helpers;
using FingridLogger.Settings;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Npgsql;

namespace FingridLogger;

public class LatestLogger(
    ILogger<LatestLogger> logger,
    IOptions<AppSettings> appSettings,
    IOptions<TimescaleDbSettings> timescaleDbSettings,
    IDatasetsApi datasetsApi)
{
    private readonly AppSettings _appSettings = appSettings.Value;
    private readonly TimescaleDbSettings _timescaleDbSettings = timescaleDbSettings.Value;
    private const int DelayBetweenCalls = 3000; // Delay in milliseconds between each API call

    private async Task UpdateLatestDatasetAsync(RealTime datasetId, CancellationToken cancellationToken = default)
    {
        try
        {
            logger.LogDebug("Fetching latest data for dataset {DatasetId}", datasetId);
            await datasetsApi.GetLastDataByDatasetAsync((int)datasetId, cancellationToken: cancellationToken)
                .ContinueWith(
                    async task => await WriteLatestEntryToTimescaleDb(task.Result, cancellationToken),
                    cancellationToken)
                .ConfigureAwait(false);
            await Task.Delay(DelayBetweenCalls, cancellationToken);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error fetching data for dataset {DatasetId}", datasetId);
        }
    }

    public async Task RunAsync(CancellationToken cancellationToken = default)
    {
        logger.LogInformation("Starting {LoggerName}", nameof(LatestLogger));

        while (!cancellationToken.IsCancellationRequested)
        {
            try
            {
                // Create a CancellationToken that gets canceled after a timeout period
                using var cts =
                    cancellationToken.ExtendWithDelayedToken(TimeSpan.FromMilliseconds(_appSettings.Timeout));

                var loopStartTime = DateTime.UtcNow;

                // Fetch the latest data for each dataset
                await UpdateLatestDatasetAsync(RealTime.Wind, cancellationToken: cts.Token);
                await UpdateLatestDatasetAsync(RealTime.Nuclear, cancellationToken: cts.Token);
                await UpdateLatestDatasetAsync(RealTime.Water, cancellationToken: cts.Token);
                await UpdateLatestDatasetAsync(RealTime.AllProduction, cancellationToken: cts.Token);
                await UpdateLatestDatasetAsync(RealTime.AllConsumption, cancellationToken: cts.Token);
                await UpdateLatestDatasetAsync(RealTime.DistrictHeating, cancellationToken: cts.Token);
                await UpdateLatestDatasetAsync(RealTime.Industrial, cancellationToken: cts.Token);
                await UpdateLatestDatasetAsync(RealTime.Other, cancellationToken: cts.Token);
                
                var loopEndTime = DateTime.UtcNow;
                var loopDuration = loopEndTime - loopStartTime;
                var delay = TimeSpan.FromMilliseconds(_appSettings.LatestLoggingInterval) - loopDuration;

                if (delay.TotalMilliseconds < 0)
                {
                    delay = TimeSpan.Zero;
                }

                logger.LogInformation("Next fetch with {LoggerName} at {DateTime} which is in {Delay}", nameof(LatestLogger), DateTimeOffset.UtcNow + delay,
                    delay.ToReadableString());
                await Task.Delay(delay, cancellationToken: cancellationToken);
            }
            catch (Exception ex)
            {
                logger.LogError(ex,
                    "Error occurred executing {LoggerName}", nameof(LatestLogger));
            }
        }
    }

    private async Task WriteLatestEntryToTimescaleDb(TimeseriesData? latestEntry,
        CancellationToken cancellationToken = default)
    {
        try
        {
            if (_timescaleDbSettings.Enabled && latestEntry != null)
            {
                try
                {
                    await using var conn = new NpgsqlConnection(_timescaleDbSettings.ConnectionString);
                    await conn.OpenAsync(cancellationToken);

                    var sql = $@"
                            INSERT INTO {_timescaleDbSettings.LatestTableName} (dataset_id, modified_at_utc, start_time, end_time, value)
                            VALUES (@dataset_id, @modified_at_utc, @start_time, @end_time, @value)
                            ON CONFLICT (dataset_id)
                            DO UPDATE SET
                                modified_at_utc = @modified_at_utc, start_time = @start_time, end_time = @end_time, value = @value
                        ";

                    await using var cmd = new NpgsqlCommand(sql, conn);
                    latestEntry.AddMetrics(cmd.Parameters);

                    await cmd.ExecuteNonQueryAsync(cancellationToken);
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