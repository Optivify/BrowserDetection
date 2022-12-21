using Optivify.BrowserDetection.DetectionData;

namespace Optivify.BrowserDetection.Platforms.Detectors
{
    public class AndroidPlatformDetector : BasePlatformDetector
    {
        public override int Order => PlatformDetectorOrders.Android;

        public override string PlatformName => PlatformNames.Android;

        public AndroidPlatformDetector(IDetectionDataLoader detectionDataLoader) : base(detectionDataLoader.GetDetectionData().Platforms)
        {
        }
    }
}
