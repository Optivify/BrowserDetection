using Optivify.DeviceDetector.DetectionData;

namespace Optivify.DeviceDetector.Browsers.Detectors;

public class EdgeBrowserDetector(IDetectionDataLoader detectionDataLoader)
    : BaseBrowserDetector(detectionDataLoader.GetCapabilityData().Browsers)
{
    public override int Order => BrowserDetectorOrders.Edge;

    public override string BrowserName => BrowserNames.Edge;
}
