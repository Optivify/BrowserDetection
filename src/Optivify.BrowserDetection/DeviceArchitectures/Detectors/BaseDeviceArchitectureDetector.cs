using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Optivify.BrowserDetection.DeviceArchitectures.Detectors
{
    public abstract class BaseDeviceArchitectureDetector : IDeviceArchitectureDetector
    {
        public abstract int Order { get; }

        public abstract string ArchitectureName { get; }

        protected Regex regex;

        protected BaseDeviceArchitectureDetector(Dictionary<string, string> architectures)
        {
            if (architectures == null || !architectures.TryGetValue(ArchitectureName, out var regexString) || string.IsNullOrEmpty(regexString))
            {
                return;
            }

            regex = new Regex(regexString, RegexOptions.Compiled);
        }

        public virtual bool TryParse(string userAgent, out IDeviceArchitecture architecture)
        {
            if (regex != null && regex.IsMatch(userAgent))
            {
                architecture = new DeviceArchitecture(ArchitectureName);

                return true;
            }

            architecture = null;

            return false;
        }
    }
}
