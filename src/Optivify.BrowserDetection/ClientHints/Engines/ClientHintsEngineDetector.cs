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

        if (parts.Length > 1)
        {
            // Engine name and version
            var engineParts = parts[1].Split(';');

            if (engineParts.Length > 1)
            {
                var engineName = ClientHintsHelpers.GetClientHintsValueFromString(engineParts[0]);
                var versionString = VersionHelpers.GetClientHintsVersionString(engineParts[1].Trim());

                if (!string.IsNullOrEmpty(engineName))
                {
                    engineName = ClientHintsHelpers.GetEngineName(engineName) ?? engineName;

                    if (VersionHelpers.TryParseSafe(versionString, out var version) && version != null)
                    {
                        return new Engine(engineName, version);
                    }
                    else
                    {
                        return new Engine(engineName, new Version());
                    }
                }
            }
        }

        return null;
    }
}
