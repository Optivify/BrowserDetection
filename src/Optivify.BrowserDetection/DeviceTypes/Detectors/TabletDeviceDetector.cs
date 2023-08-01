using Optivify.BrowserDetection.DetectionData;
using Optivify.BrowserDetection.Platforms;

namespace Optivify.BrowserDetection.DeviceTypes.Detectors;

public class TabletDeviceDetector : BaseDeviceDetector
{
    public const string TabletToken = "Tablet";

    public override int Order => DeviceDetectorOrders.Tablet;

    public override string DeviceType => DeviceTypeNames.Tablet;

    public TabletDeviceDetector(IDetectionDataLoader detectionDataLoader) : base(detectionDataLoader.GetDetectionData().Devices)
    {
    }

    public override bool TryParse(IPlatform platform, string? userAgent, out IDeviceType? device)
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

        return true;
    }
}
