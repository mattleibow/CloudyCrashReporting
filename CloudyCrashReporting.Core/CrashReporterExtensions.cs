namespace CloudyCrashReporting;

public static class CrashReporterExtensions
{
    public static MauiAppBuilder UseCoreCrashReporter(this MauiAppBuilder builder)
    {
        builder.Services.AddTransient<DotNetExceptionTester>();
        builder.Services.AddTransient<PlatformExceptionTester>();
        builder.Services.AddTransient<CrashReporterTester>();

        return builder;
    }
}
