using System.Diagnostics.CodeAnalysis;
using Optivify.BrowserDetection.Platforms;

namespace Optivify.BrowserDetection.DeviceTypes.Detectors;

public interface IDeviceTypeDetector
{
    int Order { get; }

    string DeviceType { get; }

    bool TryParse(IPlatform platform, string? userAgent, [NotNullWhen(true)] out IDeviceType? device);
}
