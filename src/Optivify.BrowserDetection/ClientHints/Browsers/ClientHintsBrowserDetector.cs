using Optivify.BrowserDetection.ClientHints.Helpers;
using Optivify.BrowserDetection.Browsers;
using Optivify.BrowserDetection.Helpers;
using System;

namespace Optivify.BrowserDetection.ClientHints.Browsers
{
    public interface IClientHintsBrowserDetector
    {
        IBrowser GetBrowser(string clientHintsUserAgent);
    }

    public class ClientHintsBrowserDetector : IClientHintsBrowserDetector
    {
        public IBrowser GetBrowser(string clientHintsUserAgent)
        {
            if (string.IsNullOrEmpty(clientHintsUserAgent))
            {
                return null;
            }

            var parts = clientHintsUserAgent.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

            if (parts.Length > 0)
            {
                // Browser name and version
                var browserNameParts = parts[2].Split(';');

                if (browserNameParts.Length > 1)
                {
                    var browserName = ClientHintsHelpers.GetBrowserName(ClientHintsHelpers.GetClientHintsValueFromString(browserNameParts[0]));
                    var versionString = VersionHelpers.GetClientHintsVersionString(ClientHintsHelpers.GetClientHintsValueFromString(browserNameParts[1]));

                    if (!string.IsNullOrEmpty(browserName))
                    {
                        if (VersionHelpers.TryParseSafe(versionString, out var version) && version != null)
                        {
                            return new Browser(browserName, version);
                        }
                        else
                        {
                            return new Browser(browserName, new Version());
                        }
                    }
                }
            }

            return null;
        }
    }
}
