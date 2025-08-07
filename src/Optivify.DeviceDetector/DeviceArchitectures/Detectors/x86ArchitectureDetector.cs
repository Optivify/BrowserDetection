using Optivify.DeviceDetector.DetectionData;

namespace Optivify.DeviceDetector.DeviceArchitectures.Detectors;

public class x86ArchitectureDetector(IDetectionDataLoader detectionDataLoader)
    : BaseDeviceArchitectureDetector(detectionDataLoader.GetCapabilityData().Architectures)
{
    public override int Order => ArchitectureDetectorOrders.x86;

    public override string ArchitectureName => DeviceArchitectureNames.x86;
}
