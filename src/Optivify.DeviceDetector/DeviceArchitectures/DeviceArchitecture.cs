namespace Optivify.DeviceDetector.DeviceArchitectures;

public class DeviceArchitecture(string name) : IDeviceArchitecture
{
    public string Name { get; } = name;
}
