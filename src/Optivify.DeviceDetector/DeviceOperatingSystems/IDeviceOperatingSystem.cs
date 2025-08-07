namespace Optivify.DeviceDetector.DeviceOperatingSystems;

public interface IDeviceOperatingSystem
{
    string Name { get; }

    Version Version { get; }
}
