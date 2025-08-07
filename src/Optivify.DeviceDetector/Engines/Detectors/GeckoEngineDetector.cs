using Optivify.DeviceDetector.DetectionData;

namespace Optivify.DeviceDetector.Engines.Detectors;

public class GeckoEngineDetector(IDetectionDataLoader detectionDataLoader)
    : BaseEngineDetector(detectionDataLoader.GetCapabilityData().Engines)
{
    public override int Order => EngineDetectorOrders.Gecko;

    public override string EngineName => EngineNames.Gecko;
}
