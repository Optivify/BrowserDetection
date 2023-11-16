using System.Diagnostics.CodeAnalysis;
using System.Text.RegularExpressions;

namespace Optivify.BrowserDetection.Helpers;

public static class VersionHelpers
{
    private static readonly Regex VersionRegex = new(@"(?:(\d+)\.)?(?:(\d+)\.)?(?:(\d+)\.\d+)", RegexOptions.Compiled);

    public static string? GetVersionString(string platformString)
    {
        var matches = VersionRegex.Matches(platformString);

        return matches.Count > 0 ? matches[0].Value : null;
    }

    public static string? GetClientHintsVersionString(string? clientHintsVersionString)
    {
        if (string.IsNullOrEmpty(clientHintsVersionString))
        {
            return clientHintsVersionString;
        }

        var parts = clientHintsVersionString.Split(new[] { '=' }, StringSplitOptions.RemoveEmptyEntries);

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
