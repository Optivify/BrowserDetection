using Optivify.DeviceDetector.DetectionData;

namespace Optivify.DeviceDetector.Platforms.Detectors;

public class MacintoshPlatformDetector(IDetectionDataLoader detectionDataLoader)
    : BasePlatformDetector(detectionDataLoader.GetCapabilityData().Platforms)
{
    public override int Order => PlatformDetectorOrders.Macintosh;

    public override string PlatformName => PlatformNames.Macintosh;
}
