using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Optivify.BrowserDetection.Platforms.Detectors
{
    public abstract class BasePlatformDetector : IPlatformDetector
    {
        public abstract int Order { get; }

        public abstract string PlatformName { get; }

        protected Regex regex;

        protected BasePlatformDetector(Dictionary<string, string> platforms)
        {
            if (platforms != null && platforms.TryGetValue(this.PlatformName, out var regexString))
            {
                if (!string.IsNullOrEmpty(regexString))
                {
                    this.regex = new Regex(regexString, RegexOptions.Compiled);
                }
            }
        }

        public virtual bool TryParse(string platformString, out IPlatform platform)
        {
            if (this.regex != null && this.regex.IsMatch(platformString))
            {
                platform = new Platform(platformString, this.PlatformName);

                return true;
            }

            platform = null;

            return false;
        }
    }
}
