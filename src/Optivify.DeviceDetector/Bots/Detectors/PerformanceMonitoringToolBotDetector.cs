using Optivify.DeviceDetector.Bots;
using Optivify.DeviceDetector.DetectionData;

namespace Optivify.DeviceDetector.Bots.Detectors;

public class PerformanceMonitoringToolBotDetector(IDetectionDataLoader detectionDataLoader)
    : BotDetectorBase(detectionDataLoader.GetCapabilityData().Bots)
{
    public override int Order => BotDetectorOrders.PerformanceMonitoringTool;

    public override string BotType => BotTypes.PerformanceMonitoringTool;
}
