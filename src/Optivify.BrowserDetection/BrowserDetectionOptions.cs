using Optivify.BrowserDetection.ClientHints;

namespace Optivify.BrowserDetection;

public class BrowserDetectionOptions
{
    public const string ConfigurationSectionName = "BrowserDetection";

    public bool SkipClientHintsDetection { get; init; }

    public AcceptClientHintsOptions AcceptClientHints { get; set; } = new();

    public CriticalClientHintsOptions CriticalClientHints { get; set; } = new();
}
