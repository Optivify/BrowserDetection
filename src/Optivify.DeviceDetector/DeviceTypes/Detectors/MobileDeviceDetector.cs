using System.Diagnostics.CodeAnalysis;
using Optivify.DeviceDetector.DetectionData;
using Optivify.DeviceDetector.Platforms;

namespace Optivify.DeviceDetector.DeviceTypes.Detectors;

public class MobileDeviceDetector(IDetectionDataLoader detectionDataLoader)
    : BaseDeviceDetector(detectionDataLoader.GetCapabilityData().Devices)
{
    public const string MobileToken = "Mobile";

    public override int Order => DeviceDetectorOrders.Phone;

    public override string DeviceType => DeviceTypeNames.Mobile;

    public override bool TryParse(IPlatform platform, string? userAgent, [NotNullWhen(true)] out IDeviceType? device)
    {
        if (base.TryParse(platform, userAgent, out device))
        {
            return true;
        }

        if (platform.Name == PlatformNames.Android && 
            userAgent is not null && 
            userAgent.Contains(MobileToken, StringComparison.OrdinalIgnoreCase))
        {
            device = new DeviceType(DeviceTypeNames.Mobile);

            return true;
        }

        device = null;

        return false;
    }
}
