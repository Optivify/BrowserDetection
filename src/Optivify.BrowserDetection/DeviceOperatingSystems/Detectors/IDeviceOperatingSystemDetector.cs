using Optivify.BrowserDetection.Platforms;

namespace Optivify.BrowserDetection.DeviceOperatingSystems.Detectors;

public interface IDeviceOperatingSystemDetector
{
    int Order { get; }

    string OperatingSystemName { get; }

    bool TryParse(IPlatform platform, string? userAgent, out IDeviceOperatingSystem? operatingSystem);
}
