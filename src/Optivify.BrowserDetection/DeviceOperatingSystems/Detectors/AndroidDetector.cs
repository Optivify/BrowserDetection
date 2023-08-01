using Optivify.BrowserDetection.DetectionData;
using Optivify.BrowserDetection.Helpers;
using Optivify.BrowserDetection.Platforms;

namespace Optivify.BrowserDetection.DeviceOperatingSystems.Detectors;

public class AndroidDetector : BaseDeviceOperatingSystemDetector
{
    public override int Order => DeviceOperatingSystemDetectorOrders.Android;

    public override string OperatingSystemName => DeviceOperatingSystemNames.Android;

    public AndroidDetector(IDetectionDataLoader detectionDataLoader) : base(detectionDataLoader.GetDetectionData().OperatingSystems)
    {
    }

    public override bool TryParse(IPlatform platform, string? userAgent, out IDeviceOperatingSystem? operatingSystem)
    {
        if (userAgent is not null && this.regex is not null)
        {
            var matches = this.regex.Matches(userAgent);

            if (matches.Count > 0)
            {
                var match = matches[0];

                if (match.Groups.Count < 2 ||
                    !VersionHelpers.TryParseSafe(match.Groups[1].ToString(), out var version) ||
                    version == null)
                {
                    operatingSystem = new DeviceOperatingSystem(this.OperatingSystemName, new Version());
                }
                else
                {
                    operatingSystem = new DeviceOperatingSystem(this.OperatingSystemName, version);
                }

                return true;
            }
        }

        operatingSystem = null;

        return false;
    }
}
