using Optivify.DeviceDetector.DetectionData;

namespace Optivify.DeviceDetector.Platforms.Detectors;

public class iPhonePlatformDetector(IDetectionDataLoader detectionDataLoader)
    : BasePlatformDetector(detectionDataLoader.GetCapabilityData().Platforms)
{
    public override int Order => PlatformDetectorOrders.iPhone;

    public override string PlatformName => PlatformNames.iPhone;
}
