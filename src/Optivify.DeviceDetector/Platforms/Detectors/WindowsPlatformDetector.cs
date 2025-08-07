using Optivify.DeviceDetector.DetectionData;

namespace Optivify.DeviceDetector.Platforms.Detectors;

public class WindowsPlatformDetector(IDetectionDataLoader detectionDataLoader)
    : BasePlatformDetector(detectionDataLoader.GetCapabilityData().Platforms)
{
    public override int Order => PlatformDetectorOrders.Windows;

    public override string PlatformName => PlatformNames.Windows;
}
