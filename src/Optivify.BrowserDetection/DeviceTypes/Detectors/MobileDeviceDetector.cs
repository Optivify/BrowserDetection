using Optivify.BrowserDetection.DetectionData;
using Optivify.BrowserDetection.Platforms;

namespace Optivify.BrowserDetection.DeviceTypes.Detectors;

public class MobileDeviceDetector : BaseDeviceDetector
{
    public const string MobileToken = "Mobile";

    public override int Order => DeviceDetectorOrders.Phone;

    public override string DeviceType => DeviceTypeNames.Mobile;

    public MobileDeviceDetector(IDetectionDataLoader detectionDataLoader) : base(detectionDataLoader.GetDetectionData().Devices)
    {
    }

    public override bool TryParse(IPlatform platform, string? userAgent, out IDeviceType? device)
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
