using Optivify.DeviceDetector.Browsers;

namespace Optivify.DeviceDetector.Capabilities.Avif;

public class AvifCapability : ICapability
{
    public const string CapabilitySpecification = "https://aomediacodec.github.io/av1-avif/";

    private readonly Dictionary<string, Version> _minimumVersions = new(StringComparer.OrdinalIgnoreCase)
    {
        [BrowserNames.Chrome] = new Version(85, 0),
        [BrowserNames.Edge] = new Version(121, 0),
        [BrowserNames.Safari] = new Version(16, 4),
        [BrowserNames.Firefox] = new Version(93, 0),
        [BrowserNames.Opera] = new Version(71, 0),
        [BrowserNames.SamsungBrowser] = new Version(14, 0),
    };

    public string Name => CapabilitySpecification;

    public bool IsSupported(string browserName, Version browserVersion)
    {
        if (_minimumVersions.TryGetValue(browserName, out var minVersion))
        {
            return browserVersion >= minVersion;
        }

        return false;
    }
}