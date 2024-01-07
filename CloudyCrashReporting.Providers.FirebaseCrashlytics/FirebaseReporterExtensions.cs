#if ANDROID
using Firebase;
#elif IOS
using Firebase.Crashlytics;
using FirebaseApp = Firebase.Core.App;
#endif

using CloudyCrashReporting.Providers.Firebase;
using Microsoft.Maui.LifecycleEvents;

namespace CloudyCrashReporting.Providers;

public static class FirebaseCrashReporterExtensions
{
    public static MauiAppBuilder UseCrashReporter(this MauiAppBuilder builder)
    {
        builder.UseCoreCrashReporter();

        builder.Services.AddTransient<ICrashReporterProvider, FirebaseCrashReporterProvider>();

        builder.ConfigureLifecycleEvents(events =>
        {
#if ANDROID
            events.AddAndroid(android =>
            {
                android.OnCreate((activity, bundle) =>
                {
                    FirebaseApp.InitializeApp(activity);
                });
            });
#elif IOS
            events.AddiOS(ios =>
            {
                ios.FinishedLaunching((app, launchOptions) =>
                {
                    FirebaseApp.Configure();

                    Crashlytics.SharedInstance.Init();
                    Crashlytics.SharedInstance.SetCrashlyticsCollectionEnabled(true);
                    Crashlytics.SharedInstance.SendUnsentReports();

                    return false;
                });
            });
#endif
        });

        return builder;
    }
}
