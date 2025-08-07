using System.Diagnostics.CodeAnalysis;
using Optivify.DeviceDetector.Platforms;

namespace Optivify.DeviceDetector.DeviceOperatingSystems.Detectors;

public interface IDeviceOperatingSystemDetector
{
    int Order { get; }

    string OperatingSystemName { get; }

    bool TryParse(IPlatform platform, string? userAgent, [NotNullWhen(true)] out IDeviceOperatingSystem? operatingSystem);
}
