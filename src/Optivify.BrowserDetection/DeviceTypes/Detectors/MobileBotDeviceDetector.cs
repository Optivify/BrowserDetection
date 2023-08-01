using Optivify.BrowserDetection.DetectionData;

namespace Optivify.BrowserDetection.DeviceTypes.Detectors;

public class MobileBotDeviceDetector : BaseDeviceDetector
{
    public override int Order => DeviceDetectorOrders.MobileBot;

    public override string DeviceType => DeviceTypeNames.MobileBot;

    public MobileBotDeviceDetector(IDetectionDataLoader detectionDataLoader) : base(detectionDataLoader.GetDetectionData().Devices)
    {
    }
}
