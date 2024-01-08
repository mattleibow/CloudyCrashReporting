namespace CloudyCrashReporting;

public class DotNetExceptionTester
{
    public DotNetExceptionTester()
    {
        ConstructionThreadId = Environment.CurrentManagedThreadId;
    }

    public int ConstructionThreadId { get; }

    public void ThrowException(string message)
    {
        var ex = new InvalidOperationException($"This exception is an [un]expected operation. " + message);
        ex.Data.Add("UserMessage", message);
        ex.Data.Add("ConstructionThreadId", ConstructionThreadId);
        ex.Data.Add("CurrentThreadId", Environment.CurrentManagedThreadId);
        throw ex;
    }
}
