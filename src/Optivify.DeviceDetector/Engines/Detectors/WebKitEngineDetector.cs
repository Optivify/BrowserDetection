using Optivify.DeviceDetector.DetectionData;

namespace Optivify.DeviceDetector.Engines.Detectors;

public class WebKitEngineDetector(IDetectionDataLoader detectionDataLoader)
    : BaseEngineDetector(detectionDataLoader.GetCapabilityData().Engines)
{
    public override int Order => EngineDetectorOrders.WebKit;

    public override string EngineName => EngineNames.WebKit;
}
