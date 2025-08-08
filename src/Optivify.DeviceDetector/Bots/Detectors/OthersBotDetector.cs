using Optivify.DeviceDetector.Bots;
using Optivify.DeviceDetector.DetectionData;

namespace Optivify.DeviceDetector.Bots.Detectors;

public class OthersBotDetector(IDetectionDataLoader detectionDataLoader)
    : BotDetectorBase(detectionDataLoader.GetCapabilityData().Bots)
{
    public override int Order => BotDetectorOrders.Others;

    public override string BotType => BotTypes.Others;
}
