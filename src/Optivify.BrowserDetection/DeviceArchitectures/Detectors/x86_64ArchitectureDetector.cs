using Optivify.BrowserDetection.DetectionData;

namespace Optivify.BrowserDetection.DeviceArchitectures.Detectors;

public class x86_64ArchitectureDetector : BaseDeviceArchitectureDetector
{
    public override int Order => ArchitectureDetectorOrders.x86_64;

    public override string ArchitectureName => DeviceArchitectureNames.x86_64;

    public x86_64ArchitectureDetector(IDetectionDataLoader detectionDataLoader) : base(detectionDataLoader.GetDetectionData().Architectures)
    {
    }
}
