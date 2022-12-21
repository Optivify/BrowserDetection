using Optivify.BrowserDetection.DetectionData;
using Optivify.BrowserDetection.Helpers;
using Optivify.BrowserDetection.Platforms;
using System;

namespace Optivify.BrowserDetection.DeviceOperatingSystems.Detectors
{
    public class AndroidDetector : BaseDeviceOperatingSystemDetector
    {
        public override int Order => DeviceOperatingSystemDetectorOrders.Android;

        public override string OperatingSystemName => DeviceOperatingSystemNames.Android;

        public AndroidDetector(IDetectionDataLoader detectionDataLoader) : base(detectionDataLoader.GetDetectionData().OperatingSystems)
        {
        }

        public override bool TryParse(IPlatform platform, string userAgent, out IDeviceOperatingSystem operatingSystem)
        {
            if (regex != null)
            {
                var matches = regex.Matches(userAgent);

                if (matches.Count > 0)
                {
                    var match = matches[0];

                    if (match.Groups.Count < 2 ||
                        !VersionHelpers.TryParseSafe(match.Groups[1].ToString(), out var version) ||
                        version == null)
                    {
                        operatingSystem = new DeviceOperatingSystem(OperatingSystemName, new Version());
                    }
                    else
                    {
                        operatingSystem = new DeviceOperatingSystem(OperatingSystemName, version);
                    }

                    return true;
                }
            }

            operatingSystem = null;

            return false;
        }
    }
}
