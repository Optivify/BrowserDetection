using Optivify.DeviceDetector.ClientHints;

namespace Optivify.DeviceDetector;

public class DeviceDetectorOptions
{
    public const string ConfigurationSectionName = "DeviceDetector";

    public bool SkipClientHintsDetection { get; init; }

    public AcceptClientHintsOptions AcceptClientHints { get; set; } = new();

    public CriticalClientHintsOptions CriticalClientHints { get; set; } = new();
}
