using Fingrid.Api;
using FingridLogger.Helpers;
using FingridLogger.Settings;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Serilog;

namespace FingridLogger;

internal class Program
{
    private static async Task Main(string[] args)
    {
        var cancellationTokenSource = new CancellationTokenSource();
        // Create service collection
        var serviceCollection = new ServiceCollection();
        ConfigureServices(serviceCollection);

        // Create service provider
        IServiceProvider serviceProvider = serviceCollection.BuildServiceProvider();

        // Example log level prints
        Log.Verbose("Verbose");
        Log.Debug("Debug");
        Log.Information("Information");
        Log.Warning("Warning");
        Log.Error("Error");
        Log.Fatal("Fatal");

        var latestLoggerTask =
            serviceProvider.GetRequiredService<LatestLogger>().RunAsync(cancellationTokenSource.Token);
        var historyForecastLoggerTask = serviceProvider.GetRequiredService<HistoryForecastLogger>()
            .RunAsync(cancellationTokenSource.Token);

        await Task.WhenAll(latestLoggerTask, historyForecastLoggerTask);
    }

    private static void ConfigureServices(IServiceCollection services)
    {
        // Build configuration
        var configuration = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .AddEnvironmentVariables()
            .AddUserSecrets<Program>()
            .Build();

        Log.Logger = new LoggerConfiguration()
            .ReadFrom.Configuration(configuration)
            .CreateLogger();

        // Add instances to DI
        services.AddSingleton<IConfiguration>(configuration);

        // Add Serilog
        services.AddLogging(config =>
        {
            config.ClearProviders();
            config.AddSerilog(dispose: true);
        });

        // Add logger
        services.AddTransient<LatestLogger>();
        services.AddTransient<HistoryForecastLogger>();

        // Add settings validators
        services.AddSingleton<IValidateOptions<AppSettings>, AppSettingsValidation>();
        services.AddSingleton<IValidateOptions<FingridSettings>, FingridSettingsValidation>();
        services.AddSingleton<IValidateOptions<TimescaleDbSettings>, TimescaleDbSettingsValidation>();

        // Add settings
        services
            .AddOptions<AppSettings>()
            .Bind(configuration.GetSection(AppSettings.SectionName))
            .ValidateOnStart();
        services
            .AddOptions<FingridSettings>()
            .Bind(configuration.GetSection(FingridSettings.SectionName))
            .ValidateOnStart();
        services
            .AddOptions<TimescaleDbSettings>()
            .Bind(configuration.GetSection(TimescaleDbSettings.SectionName))
            .ValidateOnStart();

        // Add Fingrid API clients
        services.AddSingleton<IDataApi, DataApi>((sp) =>
        {
            var settings = sp.GetRequiredService<IOptions<FingridSettings>>().Value;
            return new DataApi(settings.GetConfigurationWithApiKey(useSecondaryKeyIfAvailable: true));
        });

        services.AddSingleton<IDatasetsApi, DatasetsApi>((sp) =>
        {
            var settings = sp.GetRequiredService<IOptions<FingridSettings>>().Value;
            return new DatasetsApi(settings.GetConfigurationWithApiKey());
        });

        services.AddSingleton<IHealthcheckApi, HealthcheckApi>((sp) =>
        {
            var settings = sp.GetRequiredService<IOptions<FingridSettings>>().Value;
            return new HealthcheckApi(settings.GetConfigurationWithApiKey());
        });

        services.AddSingleton<INotificationsApi, NotificationsApi>((sp) =>
        {
            var settings = sp.GetRequiredService<IOptions<FingridSettings>>().Value;
            return new NotificationsApi(settings.GetConfigurationWithApiKey());
        });
    }
}