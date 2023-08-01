using Optivify.BrowserDetection.Browsers;
using Optivify.BrowserDetection.DeviceOperatingSystems;
using Optivify.BrowserDetection.Helpers;
using System.Text.RegularExpressions;

namespace Optivify.BrowserDetection.Engines.Detectors;

public abstract class BaseEngineDetector : IEngineDetector
{
    public abstract int Order { get; }

    public abstract string EngineName { get; }

    protected Regex? regex;

    protected BaseEngineDetector(Dictionary<string, string>? enginesRegularExpressions)
    {
        if (enginesRegularExpressions == null || !enginesRegularExpressions.TryGetValue(this.EngineName, out var regexString) || string.IsNullOrEmpty(regexString))
        {
            return;
        }

        this.regex = new Regex(regexString, RegexOptions.Compiled);
    }

    public virtual bool TryParse(IBrowser browser, IDeviceOperatingSystem operatingSystem, string? userAgent, out IEngine? engine)
    {
        if (userAgent is null)
        {
            engine = null;

            return false;
        }

        bool isBlink = false;

        if (browser.Name == BrowserNames.Chrome)
        {
            if (browser.Version.Major >= 109)
            {
                isBlink = true;
            }
            else if (browser.Version.Major >= 28 && operatingSystem.Name != DeviceOperatingSystemNames.iOS)
            {
                isBlink = true;
            }

            if (isBlink)
            {
                engine = new Engine(EngineNames.Blink, new Version(browser.Version.Major, 0));

                return true;
            }

            engine = new Engine(EngineNames.WebKit, new Version(browser.Version.Major, 0));

            return true;
        }
        else if (browser.Name == BrowserNames.Edge)
        {
            if (browser.Version.Major >= 79)
            {
                engine = new Engine(EngineNames.Blink, new Version(browser.Version.Major, 0));

                return true;
            }

            engine = new Engine(EngineNames.EdgeHTML, new Version(browser.Version.Major, 0));

            return true;
        }

        if (this.regex != null)
        {
            var matches = this.regex.Matches(userAgent);

            if (matches.Count > 0)
            {
                var match = matches[0];

                if (match.Groups.Count < 2 ||
                    !VersionHelpers.TryParseSafe(match.Groups[1].ToString(), out var version) ||
                    version == null)
                {
                    engine = new Engine(this.EngineName, new Version());
                }
                else
                {
                    engine = new Engine(this.EngineName, version);
                }

                return true;
            }
        }

        engine = null;

        return false;
    }
}
