using Optivify.BrowserDetection.DetectionData;

namespace Optivify.BrowserDetection.Platforms.Detectors
{
    public class iPhonePlatformDetector : BasePlatformDetector
    {
        public override int Order => PlatformDetectorOrders.iPhone;

        public override string PlatformName => PlatformNames.iPhone;

        public iPhonePlatformDetector(IDetectionDataLoader detectionDataLoader) : base(detectionDataLoader.GetDetectionData().Platforms)
        {
        }
    }
}
