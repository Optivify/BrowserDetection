using Optivify.BrowserDetection.Helpers;
using System.Diagnostics.CodeAnalysis;
using System.Text.RegularExpressions;

namespace Optivify.BrowserDetection.Browsers.Detectors;

public abstract class BaseBrowserDetector : IBrowserDetector
{
    public abstract int Order { get; }

    public abstract string BrowserName { get; }

    protected Regex? regex;

    protected BaseBrowserDetector(IReadOnlyDictionary<string, string>? browsers)
    {
        if (browsers == null || !browsers.TryGetValue(this.BrowserName, out var regexString) || string.IsNullOrEmpty(regexString))
        {
            return;
        }

        this.regex = new Regex(regexString, RegexOptions.Compiled);
    }

    public virtual bool TryParse(string? userAgent, [NotNullWhen(true)] out IBrowser? browser)
    {
        if (userAgent is not null && this.regex is not null)
        {
            var matches = this.regex.Matches(userAgent);

            if (matches.Count > 0)
            {
                var match = matches[0];

                browser = match.Groups.Count < 2 || !VersionHelpers.TryParseSafe(match.Groups[1].ToString(), out var version)
                    ? new Browser(this.BrowserName, new Version())
                    : new Browser(this.BrowserName, version);

                return true;
            }
        }

        browser = null;

        return false;
    }
}
