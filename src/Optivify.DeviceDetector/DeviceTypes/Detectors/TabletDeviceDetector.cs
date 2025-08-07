using System.Diagnostics.CodeAnalysis;
using Optivify.DeviceDetector.DetectionData;
using Optivify.DeviceDetector.Platforms;

namespace Optivify.DeviceDetector.DeviceTypes.Detectors;

public class TabletDeviceDetector(IDetectionDataLoader detectionDataLoader)
    : BaseDeviceDetector(detectionDataLoader.GetCapabilityData().Devices)
{
    public override int Order => DeviceDetectorOrders.Tablet;

    public override string DeviceType => DeviceTypeNames.Tablet;

    public override bool TryParse(IPlatform platform, string? userAgent, [NotNullWhen(true)] out IDeviceType? device)
    {
        if (platform.Name == PlatformNames.Android && 
            userAgent is not null && 
            !userAgent.Contains(MobileDeviceDetector.MobileToken, StringComparison.OrdinalIgnoreCase))
        {
            device = new DeviceType(DeviceTypeNames.Tablet);

            return true;
        }

        if (base.TryParse(platform, userAgent, out device))
        {
            return true;
        }

        device = null;

        return false;
    }
}
