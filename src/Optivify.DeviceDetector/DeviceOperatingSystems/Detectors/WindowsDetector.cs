using Optivify.DeviceDetector.DetectionData;

namespace Optivify.DeviceDetector.DeviceOperatingSystems.Detectors;

public class WindowsDetector(IDetectionDataLoader detectionDataLoader)
    : BaseDeviceOperatingSystemDetector(detectionDataLoader.GetCapabilityData().OperatingSystems)
{
    public override int Order => DeviceOperatingSystemDetectorOrders.Windows;

    public override string OperatingSystemName => DeviceOperatingSystemNames.Windows;
}
