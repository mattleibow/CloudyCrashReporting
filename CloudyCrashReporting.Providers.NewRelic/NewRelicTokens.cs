namespace CloudyCrashReporting.Providers.NewRelic;

static class NewRelicTokens
{
    public const string Android = "eu01xx733f1d95977a9884c141a670aa169aa9fd5b-NRMA";
    public const string iOS = "eu01xx65a2b637288e3b690f2a8be52575cd572b16-NRMA";

    public static string Token
    {
        get
        {
            if (DeviceInfo.Current.Platform == DevicePlatform.iOS)
                return iOS;
            if (DeviceInfo.Current.Platform == DevicePlatform.Android)
                return Android;
            throw new PlatformNotSupportedException("Only Android and iOS are supported.");
        }
    }
}
