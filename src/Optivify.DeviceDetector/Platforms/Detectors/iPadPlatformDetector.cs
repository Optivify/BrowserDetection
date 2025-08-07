using Optivify.DeviceDetector.DetectionData;

namespace Optivify.DeviceDetector.Platforms.Detectors;

public class iPadPlatformDetector(IDetectionDataLoader detectionDataLoader)
    : BasePlatformDetector(detectionDataLoader.GetCapabilityData().Platforms)
{
    public override int Order => PlatformDetectorOrders.iPad;

    public override string PlatformName => PlatformNames.iPad;
}
