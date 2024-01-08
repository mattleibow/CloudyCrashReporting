using Raygun4Maui;

namespace CloudyCrashReporting.Providers.Raygun;

public class RaygunCrashReporterProvider : ICrashReporterProvider
{
    public string Name => "Raygun";

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
        RaygunMauiClient.Current.Send(exception);
    }
}
