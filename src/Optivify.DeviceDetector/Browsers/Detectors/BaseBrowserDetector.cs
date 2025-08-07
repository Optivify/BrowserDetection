using System.Diagnostics.CodeAnalysis;
using System.Text.RegularExpressions;
using Optivify.DeviceDetector.Helpers;

namespace Optivify.DeviceDetector.Browsers.Detectors;

public abstract class BaseBrowserDetector : IBrowserDetector
{
    public abstract int Order { get; }

    public abstract string BrowserName { get; }

    protected Regex? Regex;

    protected BaseBrowserDetector(IReadOnlyDictionary<string, string>? browsers)
    {
        if (browsers == null || !browsers.TryGetValue(BrowserName, out var regexString) || string.IsNullOrEmpty(regexString))
        {
            return;
        }

        Regex = new Regex(regexString, RegexOptions.Compiled);
    }

    public virtual bool TryParse(string? userAgent, [NotNullWhen(true)] out IBrowser? browser)
    {
        if (userAgent is not null && Regex is not null)
        {
            var matches = Regex.Matches(userAgent);

            if (matches.Count > 0)
            {
                var match = matches[0];

                browser = match.Groups.Count < 2 || !VersionHelpers.TryParseSafe(match.Groups[1].ToString(), out var version)
                    ? new Browser(BrowserName, new Version())
                    : new Browser(BrowserName, version);

                return true;
            }
        }

        browser = null;

        return false;
    }
}
