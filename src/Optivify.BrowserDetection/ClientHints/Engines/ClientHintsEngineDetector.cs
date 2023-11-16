using Optivify.BrowserDetection.ClientHints.Helpers;
using Optivify.BrowserDetection.Engines;
using Optivify.BrowserDetection.Helpers;

namespace Optivify.BrowserDetection.ClientHints.Engines;

public interface IClientHintsEngineDetector
{
    IEngine? GetEngine(string clientHintsUserAgent);
}

public class ClientHintsEngineDetector : IClientHintsEngineDetector
{
    public IEngine? GetEngine(string clientHintsUserAgent)
    {
        if (string.IsNullOrEmpty(clientHintsUserAgent))
        {
            return null;
        }

        var parts = clientHintsUserAgent.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

        if (parts.Length <= 1)
        {
            return null;
        }

        // Engine name and version
        var engineParts = parts[1].Split(';');

        if (engineParts.Length <= 1)
        {
            
            return null;
        }
        var engineName = ClientHintsHelpers.GetClientHintsValueFromString(engineParts[0]);
        var versionString = VersionHelpers.GetClientHintsVersionString(engineParts[1].Trim());

        if (string.IsNullOrEmpty(engineName))
        {
            return null;
        }

        engineName = ClientHintsHelpers.GetEngineName(engineName) ?? engineName;

        return VersionHelpers.TryParseSafe(versionString, out var version) ? new Engine(engineName, version) : new Engine(engineName, new Version());
    }
}
