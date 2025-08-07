namespace Optivify.DeviceDetector.DeviceTypes;

public class DeviceType(string name) : IDeviceType
{
    public string Type { get; } = name;
}
