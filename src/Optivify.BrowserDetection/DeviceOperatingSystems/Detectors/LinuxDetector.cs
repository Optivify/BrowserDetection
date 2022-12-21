using Optivify.BrowserDetection.DetectionData;

namespace Optivify.BrowserDetection.DeviceOperatingSystems.Detectors
{
    public class LinuxDetector : BaseDeviceOperatingSystemDetector
    {
        public override int Order => DeviceOperatingSystemDetectorOrders.Linux;

        public override string OperatingSystemName => DeviceOperatingSystemNames.Linux;

        public LinuxDetector(IDetectionDataLoader detectionDataLoader) : base(detectionDataLoader.GetDetectionData().OperatingSystems)
        {
        }
    }
}
