using Optivify.BrowserDetection.DetectionData;

namespace Optivify.BrowserDetection.Platforms.Detectors;

public class iPadPlatformDetector : BasePlatformDetector
{
    public override int Order => PlatformDetectorOrders.iPad;

    public override string PlatformName => PlatformNames.iPad;

    public iPadPlatformDetector(IDetectionDataLoader detectionDataLoader) : base(detectionDataLoader.GetDetectionData().Platforms)
    {
    }
}
