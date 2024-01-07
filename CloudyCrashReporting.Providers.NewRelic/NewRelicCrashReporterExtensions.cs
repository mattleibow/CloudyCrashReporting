using CloudyCrashReporting.Providers.NewRelic;

namespace CloudyCrashReporting.Providers;

public static class NewRelicCrashReporterExtensions
{
    public static MauiAppBuilder UseCrashReporter(this MauiAppBuilder builder)
    {
        builder.UseCoreCrashReporter();
        
        builder.Services.AddTransient<ICrashReporterProvider, NewRelicCrashReporterProvider>();
        
        return builder;
    }
}
