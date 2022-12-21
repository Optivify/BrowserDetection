using Optivify.BrowserDetection.Helpers;
using Optivify.BrowserDetection.Platforms;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Optivify.BrowserDetection.DeviceOperatingSystems.Detectors
{
    public abstract class BaseDeviceOperatingSystemDetector : IDeviceOperatingSystemDetector
    {
        public abstract int Order { get; }

        public abstract string OperatingSystemName { get; }

        protected Regex regex;

        protected BaseDeviceOperatingSystemDetector(Dictionary<string, string> operatingSystems)
        {
            if (operatingSystems == null || !operatingSystems.TryGetValue(OperatingSystemName, out var regexString) || string.IsNullOrEmpty(regexString))
            {
                return;
            }

            regex = new Regex(regexString, RegexOptions.Compiled);
        }

        public virtual bool TryParse(IPlatform platform, string userAgent, out IDeviceOperatingSystem operatingSystem)
        {
            if (regex != null)
            {
                var platformString = platform.PlatformString;
                var matches = regex.Matches(platformString);

                if (matches.Count > 0)
                {
                    var versionString = VersionHelpers.GetVersionString(platformString);

                    if (VersionHelpers.TryParseSafe(versionString, out var version) && version != null)
                    {
                        operatingSystem = new DeviceOperatingSystem(OperatingSystemName, version);
                    }
                    else
                    {
                        operatingSystem = new DeviceOperatingSystem(OperatingSystemName, new Version());
                    }

                    return true;
                }
            }

            operatingSystem = null;

            return false;
        }
    }
}
