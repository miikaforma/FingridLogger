using Microsoft.Extensions.Options;

namespace FingridLogger.Settings;

public class AppSettings
{
    public const string SectionName = "App";
    
    public int Timeout { get; set; } = 300_000; // 5 minutes by default
    public int LatestLoggingInterval { get; set; } = 300_000; // 5 minutes by default
    public int HistoryForecastLoggingInterval { get; set; } = 300_000; // 5 minutes by default
    public int HistoryForecastInitialDelay { get; set; } = 60_000; // 1 minute by default
    public required string TimeZone { get; set; }
    public bool OfflineMode { get; set; }
}

public class AppSettingsValidation : IValidateOptions<AppSettings>
{
    public ValidateOptionsResult Validate(string? name, AppSettings settings)
    {
        if (settings.Timeout < 0)
        {
            return ValidateOptionsResult.Fail("Timeout must be greater than or equal to 0.");
        }
        
        if (settings.LatestLoggingInterval < 6000)
        {
            return ValidateOptionsResult.Fail("LatestLoggingInterval interval must be greater than or equal to 6000 (1 minute).");
        }
        
        if (settings.HistoryForecastLoggingInterval < 6000)
        {
            return ValidateOptionsResult.Fail("HistoryForecastLoggingInterval interval must be greater than or equal to 6000 (1 minute).");
        }
        
        return ValidateOptionsResult.Success;
    }
}
