using Optivify.BrowserDetection.Browsers;
using Optivify.BrowserDetection.ClientHints.Helpers;
using Optivify.BrowserDetection.Helpers;

namespace Optivify.BrowserDetection.ClientHints.Browsers;

public interface IClientHintsBrowserDetector
{
    IBrowser? GetBrowser(string clientHintsUserAgent);
}

public class ClientHintsBrowserDetector : IClientHintsBrowserDetector
{
    public IBrowser? GetBrowser(string clientHintsUserAgent)
    {
        if (string.IsNullOrEmpty(clientHintsUserAgent))
        {
            return null;
        }

        var parts = clientHintsUserAgent.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

        if (parts.Length <= 0)
        {
            return null;
        }

        // Browser name and version
        var browserNameParts = parts[2].Split(';');

        if (browserNameParts.Length <= 1)
        {
            return null;
        }

        var browserName = ClientHintsHelpers.GetBrowserName(ClientHintsHelpers.GetClientHintsValueFromString(browserNameParts[0]));
        var versionString = VersionHelpers.GetClientHintsVersionString(ClientHintsHelpers.GetClientHintsValueFromString(browserNameParts[1]));

        if (string.IsNullOrEmpty(browserName))
        {
            return null;
        }

        return VersionHelpers.TryParseSafe(versionString, out var version) ? new Browser(browserName, version) : new Browser(browserName, new Version());
    }
}
