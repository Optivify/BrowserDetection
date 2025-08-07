using System.Diagnostics.CodeAnalysis;
using System.Text.RegularExpressions;
using Optivify.DeviceDetector.Browsers;
using Optivify.DeviceDetector.DeviceOperatingSystems;
using Optivify.DeviceDetector.Helpers;

namespace Optivify.DeviceDetector.Engines.Detectors;

public abstract class BaseEngineDetector : IEngineDetector
{
    public abstract int Order { get; }

    public abstract string EngineName { get; }

    protected Regex? Regex;

    protected BaseEngineDetector(IReadOnlyDictionary<string, string>? enginesRegularExpressions)
    {
        if (enginesRegularExpressions == null || !enginesRegularExpressions.TryGetValue(EngineName, out var regexString) || string.IsNullOrEmpty(regexString))
        {
            return;
        }

        Regex = new Regex(regexString, RegexOptions.Compiled);
    }

    public virtual bool TryParse(IBrowser browser, IDeviceOperatingSystem operatingSystem, string? userAgent, [NotNullWhen(true)] out IEngine? engine)
    {
        if (userAgent is null)
        {
            engine = null;

            return false;
        }

        var isBlink = false;

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

        if (browser.Name == BrowserNames.Edge)
        {
            if (browser.Version.Major >= 79)
            {
                engine = new Engine(EngineNames.Blink, new Version(browser.Version.Major, 0));

                return true;
            }

            engine = new Engine(EngineNames.EdgeHTML, new Version(browser.Version.Major, 0));

            return true;
        }

        if (Regex != null)
        {
            var matches = Regex.Matches(userAgent);

            if (matches.Count > 0)
            {
                var match = matches[0];

                engine = match.Groups.Count < 2 || !VersionHelpers.TryParseSafe(match.Groups[1].ToString(), out var version)
                            ? new Engine(EngineName, new Version())
                            : new Engine(EngineName, version);

                return true;
            }
        }

        engine = null;

        return false;
    }
}
