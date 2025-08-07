using System.Diagnostics.CodeAnalysis;

namespace Optivify.DeviceDetector.DeviceArchitectures.Detectors;

public interface IDeviceArchitectureDetector
{
    int Order { get; }

    string ArchitectureName { get; }

    bool TryParse(string? userAgent, [NotNullWhen(true)] out IDeviceArchitecture? architecture);
}
