using Optivify.BrowserDetection.DetectionData;

namespace Optivify.BrowserDetection.Platforms.Detectors;

public class MacintoshPlatformDetector : BasePlatformDetector
{
    public override int Order => PlatformDetectorOrders.Macintosh;

    public override string PlatformName => PlatformNames.Macintosh;

    public MacintoshPlatformDetector(IDetectionDataLoader detectionDataLoader) : base(detectionDataLoader.GetDetectionData().Platforms)
    {
    }
}
