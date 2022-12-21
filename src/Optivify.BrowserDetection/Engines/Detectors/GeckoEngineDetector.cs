using Optivify.BrowserDetection.DetectionData;

namespace Optivify.BrowserDetection.Engines.Detectors
{
    public class GeckoEngineDetector : BaseEngineDetector
    {
        public override int Order => EngineDetectorOrders.Gecko;

        public override string EngineName => EngineNames.Gecko;

        public GeckoEngineDetector(IDetectionDataLoader detectionDataLoader) : base(detectionDataLoader.GetDetectionData().Engines)
        {
        }
    }
}
