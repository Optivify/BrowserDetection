using Optivify.DeviceDetector.DetectionData;

namespace Optivify.DeviceDetector.Browsers.Detectors;

public class OperaBrowserDetector(IDetectionDataLoader detectionDataLoader)
    : BaseBrowserDetector(detectionDataLoader.GetCapabilityData().Browsers)
{
    public override int Order => BrowserDetectorOrders.Opera;

    public override string BrowserName => BrowserNames.Opera;
}
