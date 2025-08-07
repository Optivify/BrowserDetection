using System.Diagnostics.CodeAnalysis;
using Optivify.DeviceDetector.Platforms;

namespace Optivify.DeviceDetector.DeviceTypes.Detectors;

public interface IDeviceTypeDetector
{
    int Order { get; }

    string DeviceType { get; }

    bool TryParse(IPlatform platform, string? userAgent, [NotNullWhen(true)] out IDeviceType? device);
}
