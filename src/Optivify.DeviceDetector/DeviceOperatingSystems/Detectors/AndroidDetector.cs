using System.Diagnostics.CodeAnalysis;
using Optivify.DeviceDetector.DetectionData;
using Optivify.DeviceDetector.Helpers;
using Optivify.DeviceDetector.Platforms;

namespace Optivify.DeviceDetector.DeviceOperatingSystems.Detectors;

public class AndroidDetector(IDetectionDataLoader detectionDataLoader)
    : BaseDeviceOperatingSystemDetector(detectionDataLoader.GetCapabilityData().OperatingSystems)
{
    public override int Order => DeviceOperatingSystemDetectorOrders.Android;

    public override string OperatingSystemName => DeviceOperatingSystemNames.Android;

    public override bool TryParse(IPlatform platform, string? userAgent, [NotNullWhen(true)] out IDeviceOperatingSystem? operatingSystem)
    {
        if (userAgent is not null && Regex is not null)
        {
            var matches = Regex.Matches(userAgent);

            if (matches.Count > 0)
            {
                var match = matches[0];

                operatingSystem = match.Groups.Count < 2 || !VersionHelpers.TryParseSafe(match.Groups[1].ToString(), out var version)
                                    ? new DeviceOperatingSystem(OperatingSystemName, new Version())
                                    : new DeviceOperatingSystem(OperatingSystemName, version);

                return true;
            }
        }

        operatingSystem = null;

        return false;
    }
}
