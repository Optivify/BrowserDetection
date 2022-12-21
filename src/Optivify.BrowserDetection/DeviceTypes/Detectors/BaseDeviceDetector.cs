using Optivify.BrowserDetection.Platforms;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Optivify.BrowserDetection.DeviceTypes.Detectors
{
    public abstract class BaseDeviceDetector : IDeviceTypeDetector
    {
        public abstract int Order { get; }

        public abstract string DeviceType { get; }

        protected List<Regex> regexList;

        protected BaseDeviceDetector(Dictionary<string, Dictionary<string, string>> devices)
        {
            if (devices == null || !devices.TryGetValue(DeviceType, out var regexStrings) || regexStrings == null)
            {
                return;
            }

            regexList = new List<Regex>();

            foreach (var regexString in regexStrings.Values)
            {
                if (!string.IsNullOrEmpty(regexString))
                {
                    regexList.Add(new Regex(regexString, RegexOptions.Compiled));
                }
            }
        }

        public virtual bool TryParse(IPlatform platform, string userAgent, out IDeviceType device)
        {
            if (regexList != null)
            {
                foreach (var regex in regexList)
                {
                    if (regex.IsMatch(platform.PlatformString))
                    {
                        device = new DeviceType(DeviceType);

                        return true;
                    }
                }
            }

            device = null;

            return false;
        }
    }
}
