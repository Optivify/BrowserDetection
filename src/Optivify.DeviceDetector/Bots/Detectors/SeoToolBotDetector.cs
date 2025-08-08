using Optivify.DeviceDetector.Bots;
using Optivify.DeviceDetector.DetectionData;

namespace Optivify.DeviceDetector.Bots.Detectors;

public class SeoToolBotDetector(IDetectionDataLoader detectionDataLoader)
    : BotDetectorBase(detectionDataLoader.GetCapabilityData().Bots)
{
    public override int Order => BotDetectorOrders.SeoTool;

    public override string BotType => BotTypes.SeoTool;
}
