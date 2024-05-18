using Fingrid.Client;
using FingridLogger.Settings;
using Npgsql;
using NpgsqlTypes;

namespace FingridLogger.Helpers;

public static class CommonExtensions
{
    public static Configuration GetConfigurationWithApiKey(this FingridSettings settings, bool useSecondaryKeyIfAvailable = false)
    {
        return new Configuration
        {
            DefaultHeaders = new Dictionary<string, string>
            {
                { "x-api-key", useSecondaryKeyIfAvailable && !string.IsNullOrWhiteSpace(settings.SecondaryApiKey) ? settings.SecondaryApiKey : settings.PrimaryApiKey }
            }
        };
    }
    
    public static CancellationTokenSource ExtendWithDelayedToken(this CancellationToken cancellationToken, TimeSpan delay)
    {
        return CancellationTokenSource.CreateLinkedTokenSource(cancellationToken,
            new CancellationTokenSource(delay).Token);
    }
    
    public static void AddNullableFloatMetric(this NpgsqlParameterCollection parameterCollection, string name, float? value)
    {
        if (value.HasValue)
        {
            parameterCollection.AddWithValue(name, value);
        }
        else
        {
            parameterCollection.Add(new NpgsqlParameter(name, NpgsqlDbType.Real) { Value = DBNull.Value });
        }
    }
    
    public static string ToReadableString(this TimeSpan span)
    {
        return string.Format("{0:0} days, {1:00} hours, {2:00} minutes, {3:00} seconds",
            span.Days, span.Hours, span.Minutes, span.Seconds);
    }
}