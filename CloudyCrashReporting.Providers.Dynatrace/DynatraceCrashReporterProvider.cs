using Dynatrace.MAUI;

namespace CloudyCrashReporting.Providers.Dynatrace;

public class DynatraceCrashReporterProvider : ICrashReporterProvider
{
    public string Name => "Dynatrace";

    public void Init()
    {
        // init is done in the builder
    }

    public void CrashNow(string message)
    {
        throw new InvalidOperationException(message);
    }

    public void RecordException(Exception exception)
    {
#if ANDROID || IOS 
        Agent.Instance.ReportError(exception.Message, exception);
#endif
    }
}
