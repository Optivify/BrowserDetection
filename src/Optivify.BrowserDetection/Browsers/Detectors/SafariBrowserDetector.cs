using Optivify.BrowserDetection.DetectionData;

namespace Optivify.BrowserDetection.Browsers.Detectors
{
    public class SafariBrowserDetector : BaseBrowserDetector
    {
        public override int Order => BrowserDetectorOrders.Safari;

        public override string BrowserName => BrowserNames.Safari;

        public SafariBrowserDetector(IDetectionDataLoader detectionDataLoader) : base(detectionDataLoader.GetDetectionData().Browsers)
        {
        }
    }
}
