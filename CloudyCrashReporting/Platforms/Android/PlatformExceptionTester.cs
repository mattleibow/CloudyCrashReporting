using Android.OS;
using Java.Lang;

namespace CloudyCrashReporting;

public partial class PlatformExceptionTester
{
    public partial void QueueInvalidOperation()
    {
        var h = new Handler(Looper.MainLooper);
        var r = new Runnable(() => { });
        h.PostDelayed(r, 1 * 1000);
        r.Dispose();
    }
}
