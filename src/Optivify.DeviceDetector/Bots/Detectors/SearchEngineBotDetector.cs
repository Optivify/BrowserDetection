using Optivify.DeviceDetector.Bots;
using Optivify.DeviceDetector.DetectionData;

namespace Optivify.DeviceDetector.Bots.Detectors;

public class SearchEngineBotDetector(IDetectionDataLoader detectionDataLoader)
    : BotDetectorBase(detectionDataLoader.GetCapabilityData().Bots)
{
    public override int Order => BotDetectorOrders.SearchEngine;

    public override string BotType => BotTypes.SearchEngine;
}
