using NewRelic.MAUI.Plugin;

namespace CloudyCrashReporting.Providers.NewRelic;

public class NewRelicCrashReporterProvider : ICrashReporterProvider
{
    public string Name => "New Relic";

    public void Init()
    {
        CrossNewRelic.Current.HandleUncaughtException();
        CrossNewRelic.Current.TrackShellNavigatedEvents();

        CrossNewRelic.Current.Start(NewRelicTokens.Token);
    }

    public void CrashNow(string message)
    {
        CrossNewRelic.Current.CrashNow(message);
    }

    public void RecordException(Exception exception)
    {
        CrossNewRelic.Current.RecordException(exception);
    }
}
