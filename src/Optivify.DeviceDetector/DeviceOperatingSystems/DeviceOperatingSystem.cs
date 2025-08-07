namespace Optivify.DeviceDetector.DeviceOperatingSystems;

public class DeviceOperatingSystem(string name, Version version) : IDeviceOperatingSystem
{
    public string Name { get; } = name;

    public Version Version { get; } = version;

    public override string ToString()
    {
        return $"{Name} - {Version}";
    }
}
