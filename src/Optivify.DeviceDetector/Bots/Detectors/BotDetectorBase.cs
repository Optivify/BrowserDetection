using System.Diagnostics.CodeAnalysis;
using System.Text.RegularExpressions;

namespace Optivify.DeviceDetector.Bots.Detectors;

public abstract class BotDetectorBase : IBotDetector
{
    public abstract int Order { get; }

    public abstract string BotType { get; }

    protected Regex? Regex;

    protected BotDetectorBase(IReadOnlyDictionary<string, string>? bots)
    {
        if (bots == null || !bots.TryGetValue(BotType, out var regexString) || string.IsNullOrEmpty(regexString))
        {
            return;
        }

        Regex = new Regex(regexString, RegexOptions.Compiled);
    }

    public virtual bool TryParse(string? userAgent, [NotNullWhen(true)] out IBot? bot)
    {
        if (userAgent is not null && Regex is not null)
        {
            var matches = Regex.Matches(userAgent);

            if (matches.Count > 0)
            {
                bot = new Bot(BotType);

                return true;
            }
        }

        bot = null;

        return false;
    }
}
