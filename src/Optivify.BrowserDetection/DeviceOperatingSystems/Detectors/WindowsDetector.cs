using Optivify.BrowserDetection.DetectionData;

namespace Optivify.BrowserDetection.DeviceOperatingSystems.Detectors;

public class WindowsDetector : BaseDeviceOperatingSystemDetector
{
    public override int Order => DeviceOperatingSystemDetectorOrders.Windows;

    public override string OperatingSystemName => DeviceOperatingSystemNames.Windows;

    public WindowsDetector(IDetectionDataLoader detectionDataLoader) : base(detectionDataLoader.GetDetectionData().OperatingSystems)
    {
    }
}
