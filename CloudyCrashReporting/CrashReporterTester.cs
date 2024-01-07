namespace CloudyCrashReporting;

public class CrashReporterTester
{
    private readonly ICrashReporterProvider _provider;
    private readonly DotNetExceptionTester _dotnetTester;
    private readonly PlatformExceptionTester _platfiormTester;

    public CrashReporterTester(DotNetExceptionTester dotnetTester, PlatformExceptionTester platfiormTester, ICrashReporterProvider provider)
    {
        _dotnetTester = dotnetTester;
        _platfiormTester = platfiormTester;
        _provider = provider;
    }

    public string ProviderName => _provider.Name;

    public void TestCrash() =>
        _provider.CrashNow("Test crash here!");

    // Handled Exceptions
	
    public void HandleDotNetException()
    {
        try
        {
            _dotnetTester.ThrowException("Handled on the UI thread.");
        }
        catch (Exception ex)
        {
            _provider.RecordException(ex);
        }
    }

    // Unhandled .NET Exceptions

    public void ThrowDotNetException()
    {
        _dotnetTester.ThrowException("From the UI thread.");
    }

    public async void ThrowDotNetTaskException()
    {
        DoThrowDotNetTaskException(_dotnetTester);
		
        GC.Collect();
        GC.WaitForPendingFinalizers();
        GC.Collect();

        static void DoThrowDotNetTaskException(DotNetExceptionTester tester)
        {
            var t = Task.Run(() =>
            {
                tester.ThrowException("From the Task thread.");
            });

            ((IAsyncResult)t).AsyncWaitHandle.WaitOne();

            t = null;
        }
    }

    public void ThrowDotNetThreadException()
    {
        var thread = new Thread(() =>
        {
            _dotnetTester.ThrowException("From a new thread.");
        });
        thread.Start();
    }

    // Unhandled Platform Exceptions

    public void ThrowPlatformException()
    {
        _platfiormTester.QueueInvalidOperation();
    }
}
