using Optivify.BrowserDetection.ClientHints;

namespace Optivify.BrowserDetection;

public class BrowserDetectionOptions
{
    public const string ConfigurationSectionName = "BrowserDetection";

    public bool SkipClientHintsDetection { get; set; }

    public AcceptClientHintsOptions AcceptClientHints { get; set; } = new AcceptClientHintsOptions();

    public CriticalClientHintsOptions CriticalClientHints { get; set; } = new CriticalClientHintsOptions();
}
