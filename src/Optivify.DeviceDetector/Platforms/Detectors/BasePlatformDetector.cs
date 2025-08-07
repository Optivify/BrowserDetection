using System.Diagnostics.CodeAnalysis;
using System.Text.RegularExpressions;

namespace Optivify.DeviceDetector.Platforms.Detectors;

public abstract class BasePlatformDetector : IPlatformDetector
{
    public abstract int Order { get; }

    public abstract string PlatformName { get; }

    protected Regex? Regex;

    protected BasePlatformDetector(IReadOnlyDictionary<string, string>? platforms)
    {
        if (platforms == null || !platforms.TryGetValue(PlatformName, out var regexString))
        {
            return;
        }

        if (!string.IsNullOrEmpty(regexString))
        {
            Regex = new Regex(regexString, RegexOptions.Compiled);
        }
    }

    public virtual bool TryParse(string platformString, [NotNullWhen(true)] out IPlatform? platform)
    {
        if (Regex is not null && Regex.IsMatch(platformString))
        {
            platform = new Platform(platformString, PlatformName);

            return true;
        }

        platform = null;

        return false;
    }
}
