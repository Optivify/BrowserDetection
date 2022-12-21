using Optivify.BrowserDetection.DetectionData;

namespace Optivify.BrowserDetection.Platforms.Detectors
{
    public class LinuxPlatformDetector : BasePlatformDetector
    {
        public override int Order => PlatformDetectorOrders.Linux;

        public override string PlatformName => PlatformNames.Linux;

        public LinuxPlatformDetector(IDetectionDataLoader detectionDataLoader) : base(detectionDataLoader.GetDetectionData().Platforms)
        {
        }
    }
}
