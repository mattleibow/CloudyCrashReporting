using Android.OS;
using Java.Lang;

namespace CloudyCrashReporting;

public partial class PlatformExceptionTester
{
    public partial void QueueInvalidOperation()
    {
        // TODO: this is not correct as the types are managed types
        
        var h = new Handler(Looper.MainLooper);
        var r = new Runnable(() => { });
        h.PostDelayed(r, 1 * 1000);
        r.Dispose();
    }
}
