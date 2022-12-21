using Optivify.BrowserDetection.DetectionData;

namespace Optivify.BrowserDetection.DeviceArchitectures.Detectors
{
    public class ARMArchitectureDetector : BaseDeviceArchitectureDetector
    {
        public override int Order => ArchitectureDetectorOrders.ARM;

        public override string ArchitectureName => DeviceArchitectureNames.ARM;

        public ARMArchitectureDetector(IDetectionDataLoader detectionDataLoader) : base(detectionDataLoader.GetDetectionData().Architectures)
        {
        }
    }
}
