using System;
using System.Text.RegularExpressions;

namespace Optivify.BrowserDetection.Helpers
{
    public static class VersionHelpers
    {
        private static readonly Regex VersionRegex = new Regex(@"(?:(\d+)\.)?(?:(\d+)\.)?(?:(\d+)\.\d+)", RegexOptions.Compiled);

        public static string GetVersionString(string platformString)
        {
            var matches = VersionRegex.Matches(platformString);

            if (matches.Count > 0)
            {
                return matches[0].Value;
            }

            return string.Empty;
        }

        public static string GetClientHintsVersionString(string clientHintsVersionString)
        {
            if (string.IsNullOrEmpty(clientHintsVersionString))
            {
                return clientHintsVersionString;
            }

            var parts = clientHintsVersionString.Split(new[] { '=' }, StringSplitOptions.RemoveEmptyEntries);

            if (parts.Length != 2)
            {
                return string.Empty;
            }

            return parts[1].Trim('"');
        }

        public static bool TryParseSafe(string versionString, out Version version)
        {
            if (string.IsNullOrEmpty(versionString))
            {
                version = new Version();

                return false;
            }

            if (!versionString.Contains("."))
            {
                return Version.TryParse(versionString + ".0", out version);
            }

            return Version.TryParse(versionString, out version);
        }
    }
}
