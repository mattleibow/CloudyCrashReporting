using CloudyCrashReporting.Providers.Dynatrace;
using Dynatrace.MAUI;

namespace CloudyCrashReporting.Providers;

public static class DynatraceCrashReporterExtensions
{
    public static MauiAppBuilder UseCrashReporter(this MauiAppBuilder builder)
    {
        builder.UseCoreCrashReporter();
        
        builder.Services.AddTransient<ICrashReporterProvider, DynatraceCrashReporterProvider>();

#if ANDROID || IOS
        // The start method is required for OneAgent to start.
        Agent.Instance.Start();
        
        // Privacy settings configured below are only provided
        // to allow a quick start with capturing monitoring data.
        // This has to be requested from the user
        // (e.g. in a privacy settings screen) and the user decision
        // has to be applied similar to this example.
        var options = new UserPrivacyOptions(DataCollectionLevel.UserBehavior, true);
        Agent.Instance.ApplyUserPrivacyOptions(options);
#endif

        return builder;
    }
}
