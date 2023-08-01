using Optivify.BrowserDetection.DetectionData;

namespace Optivify.BrowserDetection.Browsers.Detectors;

public class EdgeBrowserDetector : BaseBrowserDetector
{
    public override int Order => BrowserDetectorOrders.Edge;

    public override string BrowserName => BrowserNames.Edge;

    public EdgeBrowserDetector(IDetectionDataLoader detectionDataLoader) : base(detectionDataLoader.GetDetectionData().Browsers)
    {
    }
}
