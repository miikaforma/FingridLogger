﻿using Microsoft.Extensions.Options;

namespace FingridLogger.Settings;

public class TimescaleDbSettings
{
    public const string SectionName = "TimescaleDB";

    public bool Enabled { get; set; }
    public required string ConnectionString { get; set; }
    public string LatestTableName { get; set; } = "fingrid_latest_data";
    public string TimeSeriesTableName { get; set; } = "fingrid_time_series_data";
}

public class TimescaleDbSettingsValidation : IValidateOptions<TimescaleDbSettings>
{
    public ValidateOptionsResult Validate(string? name, TimescaleDbSettings settings)
    {
        if (string.IsNullOrWhiteSpace(settings.ConnectionString))
        {
            return ValidateOptionsResult.Fail("Connection string must be provided.");
        }

        // Disabled just in case there's some weird working connection string that doesn't match the pattern
        // var connectionStringPattern = @"^Host=.+;Username=.+;Password=.+;Database=.+$";
        // if (!Regex.IsMatch(settings.ConnectionString, connectionStringPattern))
        // {
        //     return ValidateOptionsResult.Fail("Connection string is not in the correct format.");
        // }

        return ValidateOptionsResult.Success;
    }
}
