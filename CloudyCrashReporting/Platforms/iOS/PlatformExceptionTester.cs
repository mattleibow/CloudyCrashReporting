using System.Runtime.InteropServices;
using CoreFoundation;
using ObjCRuntime;

namespace CloudyCrashReporting;

public unsafe partial class PlatformExceptionTester
{
    public partial void QueueInvalidOperation()
    {
        var ns = (ulong)TimeSpan.FromSeconds(1).TotalNanoseconds;
        var queue = DispatchQueue.MainQueue;

        dispatch_after_f(ns, queue.Handle, IntPtr.Zero, queue.Handle);
    }

    [DllImport(Constants.libcLibrary)]
    static extern void dispatch_after_f(
        /* dispatch_time_t */ ulong time,
        IntPtr queue,
        IntPtr context,
        // delegate* unmanaged<IntPtr, void> dispatchBlock);
        IntPtr dispatchBlock);
    
    [DllImport (Constants.libcLibrary)]
    static extern void dispatch_async_f (
        IntPtr queue,
        IntPtr context,
        // delegate* unmanaged<IntPtr, void> dispatch);
        IntPtr dispatch);

    [UnmanagedCallersOnly]
    static void static_dispatcher_to_managed(IntPtr context)
    {
    }
}
