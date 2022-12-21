using Optivify.BrowserDetection.Helpers;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Optivify.BrowserDetection.Browsers.Detectors
{
    public abstract class BaseBrowserDetector : IBrowserDetector
    {
        public abstract int Order { get; }

        public abstract string BrowserName { get; }

        protected Regex regex;

        protected BaseBrowserDetector(Dictionary<string, string> browsers)
        {
            if (browsers == null || !browsers.TryGetValue(BrowserName, out var regexString) || string.IsNullOrEmpty(regexString))
            {
                return;
            }

            regex = new Regex(regexString, RegexOptions.Compiled);
        }

        public virtual bool TryParse(string userAgent, out IBrowser browser)
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
                        browser = new Browser(BrowserName, new Version());
                    }
                    else
                    {
                        browser = new Browser(BrowserName, version);
                    }

                    return true;
                }
            }

            browser = null;

            return false;
        }
    }
}
