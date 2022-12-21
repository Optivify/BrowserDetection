using Optivify.BrowserDetection.DetectionData;

namespace Optivify.BrowserDetection.Browsers.Detectors
{
    public class SamsungBrowserDetector : BaseBrowserDetector
    {
        public override int Order => BrowserDetectorOrders.SamsungBrowser;

        public override string BrowserName => BrowserNames.SamsungBrowser;

        public SamsungBrowserDetector(IDetectionDataLoader detectionDataLoader) : base(detectionDataLoader.GetDetectionData().Browsers)
        {
        }
    }
}
