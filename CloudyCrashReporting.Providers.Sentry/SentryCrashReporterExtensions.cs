using CloudyCrashReporting.Providers.Sentry;

namespace CloudyCrashReporting.Providers;

public static class SentryCrashReporterExtensions
{
    public static MauiAppBuilder UseCrashReporter(this MauiAppBuilder builder)
    {
        builder.UseCoreCrashReporter();
        
        builder.Services.AddTransient<ICrashReporterProvider, SentryCrashReporterProvider>();

        builder.UseSentry(options =>
        {
            // The DSN is the only required setting.
            options.Dsn = SentryTokens.Dsn;

            // Use debug mode if you want to see what the SDK is doing.
            // Debug messages are written to stdout with Console.Writeline,
            // and are viewable in your IDE's debug console or with 'adb logcat', etc.
            // This option is not recommended when deploying your application.
            options.Debug = true;

            // Set TracesSampleRate to 1.0 to capture 100% of transactions for performance monitoring.
            // We recommend adjusting this value in production.
            options.TracesSampleRate = 1.0;

            // Configure unique user ID. 
            var userId = Preferences.Default.Get("SentryUserId", Guid.NewGuid().ToString("N"));
            Preferences.Default.Set("SentryUserId", userId);
            options.ConfigureScope(scope =>
            {
                scope.User.Id = userId;
            });
      
            // Other Sentry options can be set here.
        });
        
        return builder;
    }
}
