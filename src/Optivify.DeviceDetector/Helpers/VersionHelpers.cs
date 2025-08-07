using System.Diagnostics.CodeAnalysis;
using System.Text.RegularExpressions;

namespace Optivify.DeviceDetector.Helpers;

public static class VersionHelpers
{
    private static readonly Regex _versionRegex = new(@"(?:(\d+)\.)?(?:(\d+)\.)?(?:(\d+)\.\d+)", RegexOptions.Compiled);

    public static string? GetVersionString(string platformString)
    {
        var matches = _versionRegex.Matches(platformString);

        return matches.Count > 0 ? matches[0].Value : null;
    }

    public static string? GetClientHintsVersionString(string? clientHintsVersionString)
    {
        if (string.IsNullOrEmpty(clientHintsVersionString))
        {
            return clientHintsVersionString;
        }

        var parts = clientHintsVersionString.Split(['='], StringSplitOptions.RemoveEmptyEntries);

        return parts.Length != 2 ? string.Empty : parts[1].Trim('"');
    }

    public static bool TryParseSafe(string? versionString, [NotNullWhen(true)] out Version? version)
    {
        if (string.IsNullOrEmpty(versionString))
        {
            version = null;

            return false;
        }

        return !versionString.Contains('.') ? Version.TryParse(versionString + ".0", out version) : Version.TryParse(versionString, out version);
    }
}
