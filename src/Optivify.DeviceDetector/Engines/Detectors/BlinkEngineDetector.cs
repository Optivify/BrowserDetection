using Optivify.DeviceDetector.DetectionData;

namespace Optivify.DeviceDetector.Engines.Detectors;

public class BlinkEngineDetector(IDetectionDataLoader detectionDataLoader)
    : BaseEngineDetector(detectionDataLoader.GetCapabilityData().Engines)
{
    public override int Order => EngineDetectorOrders.Blink;

    public override string EngineName => EngineNames.Blink;
}
