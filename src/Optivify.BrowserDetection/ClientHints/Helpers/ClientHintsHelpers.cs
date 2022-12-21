using Optivify.BrowserDetection.Browsers;
using Optivify.BrowserDetection.ClientHints.Browsers;
using Optivify.BrowserDetection.ClientHints.Engines;
using Optivify.BrowserDetection.Engines;

namespace Optivify.BrowserDetection.ClientHints.Helpers
{
    public static class ClientHintsHelpers
    {
        public static string GetBrowserName(string clientHintsBrowserName)
        {
            if (string.Equals(clientHintsBrowserName, ClientHintsBrowserNames.GoogleChrome))
            {
                return BrowserNames.Chrome;
            }

            if (string.Equals(clientHintsBrowserName, ClientHintsBrowserNames.MicrosoftEdge))
            {
                return BrowserNames.Edge;
            }

            return clientHintsBrowserName;
        }

        public static string GetEngineName(string clientHintsEngineName)
        {
            if (string.Equals(clientHintsEngineName, ClientHintsEngineNames.Chromium))
            {
                return EngineNames.Blink;
            }

            return clientHintsEngineName;
        }

        public static string GetClientHintsValueFromString(string clientHintsValue)
        {
            if (clientHintsValue != null)
            {
                return clientHintsValue.Trim().Trim('"');
            }

            return clientHintsValue;
        }
    }
}
