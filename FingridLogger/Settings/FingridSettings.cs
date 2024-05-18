using Microsoft.Extensions.Options;

namespace FingridLogger.Settings;

public class FingridSettings
{
    public const string SectionName = "Fingrid";
    
    public required string PrimaryApiKey { get; set; }
    public string? SecondaryApiKey { get; set; }
}

public class FingridSettingsValidation : IValidateOptions<FingridSettings>
{
    public ValidateOptionsResult Validate(string? name, FingridSettings settings)
    {
        if (string.IsNullOrWhiteSpace(settings.PrimaryApiKey))
        {
            return ValidateOptionsResult.Fail("API key must be provided. More information from https://data.fingrid.fi/instructions.");
        }

        return ValidateOptionsResult.Success;
    }
}
