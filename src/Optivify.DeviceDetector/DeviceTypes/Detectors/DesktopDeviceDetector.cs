using System.Diagnostics.CodeAnalysis;
using Optivify.DeviceDetector.DetectionData;
using Optivify.DeviceDetector.Platforms;

namespace Optivify.DeviceDetector.DeviceTypes.Detectors;

public class DesktopDeviceDetector : BaseDeviceDetector
{
    public override int Order => DeviceDetectorOrders.Desktop;

    public override string DeviceType => DeviceTypeNames.Desktop;

    public DesktopDeviceDetector(IDetectionDataLoader detectionDataLoader) : base(detectionDataLoader.GetCapabilityData().Devices)
    {
    }

    public override bool TryParse(IPlatform platform, string? userAgent, [NotNullWhen(true)] out IDeviceType? device)
    {
        if (base.TryParse(platform, userAgent, out device))
        {
            return true;
        }

        if (platform.Name == PlatformNames.Windows ||
            platform.Name == PlatformNames.Macintosh ||
            platform.Name == PlatformNames.Linux && !platform.PlatformString.Contains("ARM", StringComparison.OrdinalIgnoreCase))
        {
            device = new DeviceType(DeviceTypeNames.Desktop);

            return true;
        }

        device = null;

        return false;
    }
}
