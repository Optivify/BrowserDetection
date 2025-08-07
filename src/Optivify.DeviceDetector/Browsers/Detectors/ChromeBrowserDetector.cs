using Optivify.DeviceDetector.DetectionData;

namespace Optivify.DeviceDetector.Browsers.Detectors;

public class ChromeBrowserDetector(IDetectionDataLoader detectionDataLoader)
    : BaseBrowserDetector(detectionDataLoader.GetCapabilityData().Browsers)
{
    public override int Order => BrowserDetectorOrders.Chrome;

    public override string BrowserName => BrowserNames.Chrome;
}
