using System.Diagnostics.CodeAnalysis;

namespace Optivify.BrowserDetection.DeviceArchitectures.Detectors;

public interface IDeviceArchitectureDetector
{
    int Order { get; }

    string ArchitectureName { get; }

    bool TryParse(string? userAgent, [NotNullWhen(true)] out IDeviceArchitecture? architecture);
}
