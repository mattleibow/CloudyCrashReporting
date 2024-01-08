namespace CloudyCrashReporting;

public interface ICrashReporterProvider
{
    string Name { get; }
    
    void Init();

    void CrashNow(string message);
    
    void RecordException(Exception exception);
}
