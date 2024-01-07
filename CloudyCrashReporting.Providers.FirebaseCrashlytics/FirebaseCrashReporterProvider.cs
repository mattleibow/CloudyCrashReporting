#if ANDROID
using Crashlytics = Firebase.Crashlytics.FirebaseCrashlytics; 
#elif IOS
using Foundation;
using Firebase.Crashlytics;
#endif

namespace CloudyCrashReporting.Providers.Firebase;

public class FirebaseCrashReporterProvider : ICrashReporterProvider
{
    public string Name => "Firebase Crashlytics";

    public void Init()
    {
        // init is done in the builder
    }

    public void CrashNow(string message)
    {
#if ANDROID
        throw new Java.Lang.Exception("Test Crash");
#elif IOS
        var error = new NSError(NSError.CocoaErrorDomain, -1001);
        throw new NSErrorException(error);
#endif
    }

    public void RecordException(Exception exception)
    {
#if ANDROID
        var throwable = Java.Lang.Throwable.FromException(exception);
        Crashlytics.Instance.RecordException(throwable);
#elif IOS
        var errorInfo = new Dictionary<object, object>
        {
            [NSError.LocalizedDescriptionKey] = NSBundle.MainBundle.GetLocalizedString(exception.Message, null),
            [NSError.LocalizedFailureReasonErrorKey] = NSBundle.MainBundle.GetLocalizedString("Managed Failure", null),
            [NSError.LocalizedRecoverySuggestionErrorKey] = NSBundle.MainBundle.GetLocalizedString ("Recovery Suggestion", null),
        };

        var error = new NSError(
            new NSString("NonFatalError"),
            -1001,
            NSDictionary.FromObjectsAndKeys(errorInfo.Values.ToArray(), errorInfo.Keys.ToArray(), errorInfo.Keys.Count));

        Crashlytics.SharedInstance.RecordError(error);
#endif
    }
}
