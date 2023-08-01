using Optivify.BrowserDetection.ClientHints;

namespace Optivify.BrowserDetection.DependencyInjection;

public static class Defaults
{
    public static BrowserDetectionOptions CreateOptions()
        => new()
        {
            AcceptClientHints = new AcceptClientHintsOptions
            {
                AcceptDevicePixelRatio = true,
                AcceptPlatformVersion = true,
                AcceptUserAgentArch = true,
                AcceptUserAgentBitness = true,
                AcceptUserAgentFullVersion = true,
                AcceptUserAgentFullVersionList = true,
                AcceptUserAgentModel = true,
                AcceptViewportWidth = true,
                AcceptViewportHeight = true,
                AcceptWidth = true
            },
            CriticalClientHints = new CriticalClientHintsOptions
            {
                AcceptUserAgentModel = true,
                AcceptPlatformVersion = true,
                AcceptUserAgentFullVersion = true,
                AcceptUserAgentFullVersionList = true,
                AcceptViewportWidth = true,
                AcceptViewportHeight = true,
                AcceptWidth = true,
                AcceptDevicePixelRatio = true,
                AcceptUserAgentArch = true,
                AcceptUserAgentBitness = true
            },
            SkipClientHintsDetection = false
        };
}