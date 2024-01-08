namespace CloudyCrashReporting.ClientApp;

public partial class MainPage : ContentPage
{
	private readonly CrashReporterTester _tester;

	public MainPage(CrashReporterTester tester)
	{
		_tester = tester;
		BindingContext = _tester;

		InitializeComponent();
	}

	private void TestCrash(object? sender, EventArgs e) =>
		_tester.TestCrash();

	// Handled Exceptions

	private void HandleDotNetException(object? sender, EventArgs e) =>
		_tester.HandleDotNetException();

	// Unhandled .NET Exceptions

	private void ThrowDotNetException(object? sender, EventArgs e) =>
		_tester.ThrowDotNetException();

	private void ThrowDotNetTaskException(object? sender, EventArgs e) =>
		_tester.ThrowDotNetTaskException();

	private void ThrowDotNetAwaitedTaskException(object? sender, EventArgs e) =>
		_tester.ThrowDotNetAwaitedTaskException();

	private void ThrowDotNetThreadException(object? sender, EventArgs e) =>
		_tester.ThrowDotNetThreadException();

	// Unhandled Platform Exceptions

	private void ThrowPlatformException(object? sender, EventArgs e) =>
		_tester.ThrowPlatformException();
}
