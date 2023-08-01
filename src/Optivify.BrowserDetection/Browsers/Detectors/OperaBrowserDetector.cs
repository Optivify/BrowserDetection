using Optivify.BrowserDetection.DetectionData;

namespace Optivify.BrowserDetection.Browsers.Detectors;

public class OperaBrowserDetector : BaseBrowserDetector
{
    public override int Order => BrowserDetectorOrders.Opera;

    public override string BrowserName => BrowserNames.Opera;

    public OperaBrowserDetector(IDetectionDataLoader detectionDataLoader) : base(detectionDataLoader.GetDetectionData().Browsers)
    {
    }
}
