using Optivify.DeviceDetector.DetectionData;

namespace Optivify.DeviceDetector.Browsers.Detectors;

public class FirefoxBrowserDetector(IDetectionDataLoader detectionDataLoader)
    : BaseBrowserDetector(detectionDataLoader.GetCapabilityData().Browsers)
{
    public override int Order => BrowserDetectorOrders.Firefox;

    public override string BrowserName => BrowserNames.Firefox;
}
