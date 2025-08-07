using Optivify.DeviceDetector.DetectionData;

namespace Optivify.DeviceDetector.Platforms.Detectors;

public class AndroidPlatformDetector(IDetectionDataLoader detectionDataLoader)
    : BasePlatformDetector(detectionDataLoader.GetCapabilityData().Platforms)
{
    public override int Order => PlatformDetectorOrders.Android;

    public override string PlatformName => PlatformNames.Android;
}
