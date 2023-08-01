using Optivify.BrowserDetection.Helpers;
using Optivify.BrowserDetection.Platforms;
using System.Text.RegularExpressions;

namespace Optivify.BrowserDetection.DeviceOperatingSystems.Detectors;

public abstract class BaseDeviceOperatingSystemDetector : IDeviceOperatingSystemDetector
{
    public abstract int Order { get; }

    public abstract string OperatingSystemName { get; }

    protected Regex? regex;

    protected BaseDeviceOperatingSystemDetector(Dictionary<string, string>? operatingSystems)
    {
        if (operatingSystems == null || !operatingSystems.TryGetValue(this.OperatingSystemName, out var regexString) || string.IsNullOrEmpty(regexString))
        {
            return;
        }

        this.regex = new Regex(regexString, RegexOptions.Compiled);
    }

    public virtual bool TryParse(IPlatform platform, string? userAgent, out IDeviceOperatingSystem? operatingSystem)
    {
        if (userAgent is not null && this.regex is not null)
        {
            var platformString = platform.PlatformString;
            var matches = this.regex.Matches(platformString);

            if (matches.Count > 0)
            {
                var versionString = VersionHelpers.GetVersionString(platformString);

                if (VersionHelpers.TryParseSafe(versionString, out var version) && version != null)
                {
                    operatingSystem = new DeviceOperatingSystem(this.OperatingSystemName, version);
                }
                else
                {
                    operatingSystem = new DeviceOperatingSystem(this.OperatingSystemName, new Version());
                }

                return true;
            }
        }

        operatingSystem = null;

        return false;
    }
}
