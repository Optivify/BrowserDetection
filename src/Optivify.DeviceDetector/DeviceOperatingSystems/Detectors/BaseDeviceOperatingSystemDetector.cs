using System.Diagnostics.CodeAnalysis;
using System.Text.RegularExpressions;
using Optivify.DeviceDetector.Helpers;
using Optivify.DeviceDetector.Platforms;

namespace Optivify.DeviceDetector.DeviceOperatingSystems.Detectors;

public abstract class BaseDeviceOperatingSystemDetector : IDeviceOperatingSystemDetector
{
    public abstract int Order { get; }

    public abstract string OperatingSystemName { get; }

    protected Regex? Regex;

    protected BaseDeviceOperatingSystemDetector(IReadOnlyDictionary<string, string>? operatingSystems)
    {
        if (operatingSystems == null || !operatingSystems.TryGetValue(OperatingSystemName, out var regexString) || string.IsNullOrEmpty(regexString))
        {
            return;
        }

        Regex = new Regex(regexString, RegexOptions.Compiled);
    }

    public virtual bool TryParse(IPlatform platform, string? userAgent, [NotNullWhen(true)] out IDeviceOperatingSystem? operatingSystem)
    {
        if (userAgent is not null && Regex is not null)
        {
            var platformString = platform.PlatformString;
            var matches = Regex.Matches(platformString);

            if (matches.Count > 0)
            {
                var versionString = VersionHelpers.GetVersionString(platformString);

                operatingSystem = VersionHelpers.TryParseSafe(versionString, out var version) 
                                    ? new DeviceOperatingSystem(OperatingSystemName, version) 
                                    : new DeviceOperatingSystem(OperatingSystemName, new Version());

                return true;
            }
        }

        operatingSystem = null;

        return false;
    }
}
