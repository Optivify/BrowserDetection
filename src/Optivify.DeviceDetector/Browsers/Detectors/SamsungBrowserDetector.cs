using Optivify.DeviceDetector.DetectionData;

namespace Optivify.DeviceDetector.Browsers.Detectors;

public class SamsungBrowserDetector(IDetectionDataLoader detectionDataLoader)
    : BaseBrowserDetector(detectionDataLoader.GetCapabilityData().Browsers)
{
    public override int Order => BrowserDetectorOrders.SamsungBrowser;

    public override string BrowserName => BrowserNames.SamsungBrowser;
}
