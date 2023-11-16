using System.Diagnostics.CodeAnalysis;
using System.Text.RegularExpressions;

namespace Optivify.BrowserDetection.Platforms.Detectors;

public abstract class BasePlatformDetector : IPlatformDetector
{
    public abstract int Order { get; }

    public abstract string PlatformName { get; }

    protected Regex? regex;

    protected BasePlatformDetector(IReadOnlyDictionary<string, string>? platforms)
    {
        if (platforms == null || !platforms.TryGetValue(this.PlatformName, out var regexString))
        {
            return;
        }

        if (!string.IsNullOrEmpty(regexString))
        {
            this.regex = new Regex(regexString, RegexOptions.Compiled);
        }
    }

    public virtual bool TryParse(string platformString, [NotNullWhen(true)] out IPlatform? platform)
    {
        if (this.regex is not null && this.regex.IsMatch(platformString))
        {
            platform = new Platform(platformString, this.PlatformName);

            return true;
        }

        platform = null;

        return false;
    }
}
