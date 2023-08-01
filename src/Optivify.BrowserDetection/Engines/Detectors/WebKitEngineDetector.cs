using Optivify.BrowserDetection.DetectionData;

namespace Optivify.BrowserDetection.Engines.Detectors;

public class WebKitEngineDetector : BaseEngineDetector
{
    public override int Order => EngineDetectorOrders.WebKit;

    public override string EngineName => EngineNames.WebKit;

    public WebKitEngineDetector(IDetectionDataLoader detectionDataLoader) : base(detectionDataLoader.GetDetectionData().Engines)
    {
    }
}
