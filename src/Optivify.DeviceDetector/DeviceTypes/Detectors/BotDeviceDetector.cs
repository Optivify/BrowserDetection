using Optivify.DeviceDetector.DetectionData;

namespace Optivify.DeviceDetector.DeviceTypes.Detectors;

public class BotDeviceDetector(IDetectionDataLoader detectionDataLoader)
    : BaseDeviceDetector(detectionDataLoader.GetCapabilityData().Devices)
{
    public override int Order => DeviceDetectorOrders.Bot;

    public override string DeviceType => DeviceTypeNames.Bot;
}
