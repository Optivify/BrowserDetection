using Optivify.DeviceDetector.Browsers;
using Optivify.DeviceDetector.ClientHints;
using Optivify.DeviceDetector.DeviceArchitectures;
using Optivify.DeviceDetector.DeviceOperatingSystems;
using Optivify.DeviceDetector.DeviceTypes;
using Optivify.DeviceDetector.Engines;
using Optivify.DeviceDetector.Platforms;
using Optivify.DeviceDetector.UserAgents;

namespace Optivify.DeviceDetector.Services;

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

    string? Model { get; }

    int? ViewportWidth { get; }

    int? ViewportHeight { get; }

    DeviceDetectorOptions DeviceDetectorOptions { get; }

    void SetOptions(DeviceDetectorOptions deviceDetectorOptions);
}
