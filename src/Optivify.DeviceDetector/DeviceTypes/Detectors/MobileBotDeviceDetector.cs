using Optivify.DeviceDetector.DetectionData;

namespace Optivify.DeviceDetector.DeviceTypes.Detectors;

public class MobileBotDeviceDetector(IDetectionDataLoader detectionDataLoader)
    : BaseDeviceDetector(detectionDataLoader.GetCapabilityData().Devices)
{
    public override int Order => DeviceDetectorOrders.MobileBot;

    public override string DeviceType => DeviceTypeNames.MobileBot;
}
