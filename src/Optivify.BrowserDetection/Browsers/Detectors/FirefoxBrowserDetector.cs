using Optivify.BrowserDetection.DetectionData;

namespace Optivify.BrowserDetection.Browsers.Detectors;

public class FirefoxBrowserDetector : BaseBrowserDetector
{
    public override int Order => BrowserDetectorOrders.Firefox;

    public override string BrowserName => BrowserNames.Firefox;

    public FirefoxBrowserDetector(IDetectionDataLoader detectionDataLoader) : base(detectionDataLoader.GetDetectionData().Browsers)
    {
    }
}
