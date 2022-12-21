using Optivify.BrowserDetection.DetectionData;

namespace Optivify.BrowserDetection.DeviceTypes.Detectors
{
    public class BotDeviceDetector : BaseDeviceDetector
    {
        public override int Order => DeviceDetectorOrders.Bot;

        public override string DeviceType => DeviceTypeNames.Bot;

        public BotDeviceDetector(IDetectionDataLoader detectionDataLoader) : base(detectionDataLoader.GetDetectionData().Devices)
        {
        }
    }
}
