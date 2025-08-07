using Optivify.DeviceDetector.DetectionData;

namespace Optivify.DeviceDetector.DeviceArchitectures.Detectors;

public class x86_64ArchitectureDetector(IDetectionDataLoader detectionDataLoader)
    : BaseDeviceArchitectureDetector(detectionDataLoader.GetCapabilityData().Architectures)
{
    public override int Order => ArchitectureDetectorOrders.x86_64;

    public override string ArchitectureName => DeviceArchitectureNames.x86_64;
}
