using Sentry;

namespace CloudyCrashReporting.Providers.Sentry;

public class SentryCrashReporterProvider : ICrashReporterProvider
{
    public string Name => "Sentry.io";

    public void Init()
    {
        // init is done in the builder
        
        // SentrySdk.CaptureMessage("Hello Sentry");
    }

    public void CrashNow(string message)
    {
        SentrySdk.CauseCrash(CrashType.Managed);
    }

    public void RecordException(Exception exception)
    {
        SentrySdk.CaptureException(exception);
    }
}
