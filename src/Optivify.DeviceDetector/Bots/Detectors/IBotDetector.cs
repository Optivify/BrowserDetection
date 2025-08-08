using Optivify.DeviceDetector.Bots;
using System.Diagnostics.CodeAnalysis;

namespace Optivify.DeviceDetector.Bots.Detectors;

public interface IBotDetector
{
    int Order { get; }

    string BotType { get; }

    bool TryParse(string? userAgent, [NotNullWhen(true)] out IBot? bot);
}
