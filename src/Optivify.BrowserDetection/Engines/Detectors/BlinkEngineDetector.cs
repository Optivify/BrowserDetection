using Optivify.BrowserDetection.DetectionData;

namespace Optivify.BrowserDetection.Engines.Detectors
{
    public class BlinkEngineDetector : BaseEngineDetector
    {
        public override int Order => EngineDetectorOrders.Blink;

        public override string EngineName => EngineNames.Blink;

        public BlinkEngineDetector(IDetectionDataLoader detectionDataLoader) : base(detectionDataLoader.GetDetectionData().Engines)
        {
        }
    }
}
