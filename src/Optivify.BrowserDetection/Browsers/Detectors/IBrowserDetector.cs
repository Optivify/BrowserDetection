using System.Diagnostics.CodeAnalysis;

namespace Optivify.BrowserDetection.Browsers.Detectors;

public interface IBrowserDetector
{
    int Order { get; }

    string BrowserName { get; }

    bool TryParse(string? userAgent, [NotNullWhen(true)] out IBrowser? browser);
}
