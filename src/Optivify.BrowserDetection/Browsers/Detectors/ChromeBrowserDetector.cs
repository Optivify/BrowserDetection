using Optivify.BrowserDetection.DetectionData;

namespace Optivify.BrowserDetection.Browsers.Detectors
{
    public class ChromeBrowserDetector : BaseBrowserDetector
    {
        public override int Order => BrowserDetectorOrders.Chrome;

        public override string BrowserName => BrowserNames.Chrome;

        public ChromeBrowserDetector(IDetectionDataLoader detectionDataLoader) : base(detectionDataLoader.GetDetectionData().Browsers)
        {
        }
    }
}
