using Optivify.DeviceDetector.DetectionData;

namespace Optivify.DeviceDetector.DeviceOperatingSystems.Detectors;

public class LinuxDetector(IDetectionDataLoader detectionDataLoader)
    : BaseDeviceOperatingSystemDetector(detectionDataLoader.GetCapabilityData().OperatingSystems)
{
    public override int Order => DeviceOperatingSystemDetectorOrders.Linux;

    public override string OperatingSystemName => DeviceOperatingSystemNames.Linux;
}
