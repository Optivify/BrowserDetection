using System.Diagnostics.CodeAnalysis;

namespace Optivify.BrowserDetection.Platforms.Detectors;

public interface IPlatformDetector
{
    int Order { get; }

    string PlatformName { get; }

    bool TryParse(string platformString, [NotNullWhen(true)] out IPlatform? platform);
}
