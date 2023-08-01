namespace Optivify.BrowserDetection.Engines;

public static class EngineNames
{
    public const string Blink = "Blink";        // Google Chrome, Microsoft Edge >= 79, Opera, Brave

    public const string WebKit = "WebKit";      // Safari, Firefox for iOS, Microsoft Edge for iOS

    public const string Gecko = "Gecko";        // Firefox

    public const string EdgeHTML = "EdgeHTML";  // Microsoft Edge < 79

    public const string Others = "Others";      // Others
}
