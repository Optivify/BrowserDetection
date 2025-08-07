using System.Diagnostics.CodeAnalysis;
using Optivify.DeviceDetector.Browsers;
using Optivify.DeviceDetector.DeviceOperatingSystems;

namespace Optivify.DeviceDetector.Engines.Detectors;

public interface IEngineDetector
{
    int Order { get; }

    string EngineName { get; }

    bool TryParse(IBrowser browser, IDeviceOperatingSystem operatingSystem, string? userAgent, [NotNullWhen(true)] out IEngine? engine);
}
