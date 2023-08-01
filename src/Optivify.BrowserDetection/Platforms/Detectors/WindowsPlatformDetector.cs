using Optivify.BrowserDetection.DetectionData;

namespace Optivify.BrowserDetection.Platforms.Detectors;

public class WindowsPlatformDetector : BasePlatformDetector
{
    public override int Order => PlatformDetectorOrders.Windows;

    public override string PlatformName => PlatformNames.Windows;

    public WindowsPlatformDetector(IDetectionDataLoader detectionDataLoader) : base(detectionDataLoader.GetDetectionData().Platforms)
    {
    }
}
