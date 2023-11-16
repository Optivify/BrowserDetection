using Optivify.BrowserDetection.Browsers;
using Optivify.BrowserDetection.ClientHints.Browsers;
using Optivify.BrowserDetection.ClientHints.Engines;
using Optivify.BrowserDetection.Engines;

namespace Optivify.BrowserDetection.ClientHints.Helpers;

public static class ClientHintsHelpers
{
    public static string? GetBrowserName(string? clientHintsBrowserName)
    {
        if (string.Equals(clientHintsBrowserName, ClientHintsBrowserNames.GoogleChrome))
        {
            return BrowserNames.Chrome;
        }

        return string.Equals(clientHintsBrowserName, ClientHintsBrowserNames.MicrosoftEdge) ? BrowserNames.Edge : clientHintsBrowserName;
    }

    public static string? GetEngineName(string? clientHintsEngineName)
    {
        return string.Equals(clientHintsEngineName, ClientHintsEngineNames.Chromium) ? EngineNames.Blink : clientHintsEngineName;
    }

    public static string? GetClientHintsValueFromString(string? clientHintsValue)
    {
        return clientHintsValue != null ? clientHintsValue.Trim().Trim('"') : clientHintsValue;
    }
}
