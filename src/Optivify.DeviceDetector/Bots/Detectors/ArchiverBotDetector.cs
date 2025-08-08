using Optivify.DeviceDetector.Bots;
using Optivify.DeviceDetector.DetectionData;

namespace Optivify.DeviceDetector.Bots.Detectors;

public class ArchiverBotDetector(IDetectionDataLoader detectionDataLoader)
    : BotDetectorBase(detectionDataLoader.GetCapabilityData().Bots)
{
    public override int Order => BotDetectorOrders.Archiver;

    public override string BotType => BotTypes.Archiver;
}
