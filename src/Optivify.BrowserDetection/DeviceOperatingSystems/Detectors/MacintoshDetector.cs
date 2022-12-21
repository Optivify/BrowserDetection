using Optivify.BrowserDetection.DetectionData;
using Optivify.BrowserDetection.Platforms;

namespace Optivify.BrowserDetection.DeviceOperatingSystems.Detectors
{
    public class MacintoshDetector : BaseDeviceOperatingSystemDetector
    {
        public override int Order => DeviceOperatingSystemDetectorOrders.Macintosh;

        public override string OperatingSystemName => DeviceOperatingSystemNames.Macintosh;

        public MacintoshDetector(IDetectionDataLoader detectionDataLoader) : base(detectionDataLoader.GetDetectionData().OperatingSystems)
        {
        }

        public override bool TryParse(IPlatform platform, string userAgent, out IDeviceOperatingSystem operatingSystem)
        {
            platform = new Platform(platform.PlatformString.Replace('_', '.'), platform.Name);

            return base.TryParse(platform, userAgent, out operatingSystem);
        }
    }
}
