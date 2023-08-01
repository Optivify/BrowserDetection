namespace Optivify.BrowserDetection.ClientHints.Headers;

public static class RequestHeaderNames
{
    #region Low Entropy

    public const string UserAgent = "Sec-CH-UA";

    public const string UserAgentMobile = "Sec-CH-UA-Mobile";

    public const string UserAgentPlatform = "Sec-CH-UA-Platform";

    #endregion

    #region High Entropy

    public const string UserAgentArch = "Sec-CH-UA-Arch";

    public const string UserAgentBitness = "Sec-CH-UA-Bitness";

    public const string UserAgentFullVersion = "Sec-CH-UA-Full-Version";

    public const string UserAgentFullVersionList = "Sec-CH-UA-Full-Version-List";

    public const string UserAgentModel = "Sec-CH-UA-Model";

    public const string DevicePixelRatio = "Sec-CH-DPR";

    public const string PlatformVersion = "Sec-CH-UA-Platform-Version";

    public const string ViewportWidth = "Sec-CH-Viewport-Width";

    public const string ViewportHeight = "Sec-CH-Viewport-Height";

    public const string Width = "Width";

    #endregion
}
