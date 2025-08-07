using System.Diagnostics.CodeAnalysis;
using Optivify.DeviceDetector.DetectionData;
using Optivify.DeviceDetector.Platforms;

namespace Optivify.DeviceDetector.DeviceOperatingSystems.Detectors;

public class MacintoshDetector(IDetectionDataLoader detectionDataLoader)
    : BaseDeviceOperatingSystemDetector(detectionDataLoader.GetCapabilityData().OperatingSystems)
{
    public override int Order => DeviceOperatingSystemDetectorOrders.Macintosh;

    public override string OperatingSystemName => DeviceOperatingSystemNames.Macintosh;

    public override bool TryParse(IPlatform platform, string? userAgent, [NotNullWhen(true)] out IDeviceOperatingSystem? operatingSystem)
    {
        platform = new Platform(platform.PlatformString.Replace('_', '.'), platform.Name);

        return base.TryParse(platform, userAgent, out operatingSystem);
    }
}
