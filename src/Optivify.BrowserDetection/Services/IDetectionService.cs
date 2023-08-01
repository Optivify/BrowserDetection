using Optivify.BrowserDetection.Browsers;
using Optivify.BrowserDetection.ClientHints;
using Optivify.BrowserDetection.DeviceArchitectures;
using Optivify.BrowserDetection.DeviceOperatingSystems;
using Optivify.BrowserDetection.DeviceTypes;
using Optivify.BrowserDetection.Engines;
using Optivify.BrowserDetection.Platforms;
using Optivify.BrowserDetection.UserAgents;

namespace Optivify.BrowserDetection.Services;

public interface IDetectionService
{
    IClientHintsResolver ClientHintsResolver { get; }

    IUserAgentResolver UserAgentResolver { get; }

    IEngine Engine { get; }

    IBrowser Browser { get; }

    IPlatform Platform { get; }

    IDeviceType Device { get; }

    IDeviceOperatingSystem OperatingSystem { get; }

    IDeviceArchitecture Architecture { get; }

    double? DevicePixelRatio { get; }

    string Model { get; }

    int? ViewportWidth { get; }

    int? ViewportHeight { get; }

    BrowserDetectionOptions BrowserDetectionOptions { get; }

    void SetBrowserDetectionOptions(BrowserDetectionOptions browserDetectionOptions);
}
