namespace Optivify.BrowserDetection.DeviceOperatingSystems;

public class DeviceOperatingSystem : IDeviceOperatingSystem
{
    public string Name { get; }

    public Version Version { get; }

    public DeviceOperatingSystem(string name, Version version)
    {
        this.Name = name;
        this.Version = version;
    }

    public override string ToString()
    {
        return $"{this.Name} - {this.Version}";
    }
}
