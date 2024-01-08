using CloudyCrashReporting.Providers.Raygun;
using Raygun4Maui;

namespace CloudyCrashReporting.Providers;

public static class RaygunCrashReporterExtensions
{
    public static MauiAppBuilder UseCrashReporter(this MauiAppBuilder builder)
    {
        builder.UseCoreCrashReporter();
        
        builder.Services.AddTransient<ICrashReporterProvider, RaygunCrashReporterProvider>();

        builder.AddRaygun(options =>
        {
            options.RaygunSettings.ApiKey = RaygunTokens.ApiKey;
            options.RaygunSettings.CatchUnhandledExceptions = true;
            
            options.EnableRealUserMonitoring = true;
            options.RumFeatureFlags = RumFeatures.Page | RumFeatures.Network | RumFeatures.AppleNativeTimings;
        });
        
        return builder;
    }
}
