using Optivify.DeviceDetector.DetectionData;

namespace Optivify.DeviceDetector.DeviceArchitectures.Detectors;

public class ARMArchitectureDetector(IDetectionDataLoader detectionDataLoader)
    : BaseDeviceArchitectureDetector(detectionDataLoader.GetCapabilityData().Architectures)
{
    public override int Order => ArchitectureDetectorOrders.ARM;

    public override string ArchitectureName => DeviceArchitectureNames.ARM;
}
