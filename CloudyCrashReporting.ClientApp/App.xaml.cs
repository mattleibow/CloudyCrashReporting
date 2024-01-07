namespace CloudyCrashReporting.ClientApp;

public partial class App : Application
{
	public App(ICrashReporterProvider provider)
	{
		InitializeComponent();

		MainPage = new AppShell();
		
		provider.Init();
	}
}
