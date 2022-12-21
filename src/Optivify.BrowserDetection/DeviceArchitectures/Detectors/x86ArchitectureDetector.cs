using Optivify.BrowserDetection.DetectionData;

namespace Optivify.BrowserDetection.DeviceArchitectures.Detectors
{
    public class x86ArchitectureDetector : BaseDeviceArchitectureDetector
    {
        public override int Order => ArchitectureDetectorOrders.x86;

        public override string ArchitectureName => DeviceArchitectureNames.x86;

        public x86ArchitectureDetector(IDetectionDataLoader detectionDataLoader) : base(detectionDataLoader.GetDetectionData().Architectures)
        {
        }
    }
}
