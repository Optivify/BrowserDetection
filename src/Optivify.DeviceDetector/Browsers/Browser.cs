namespace Optivify.DeviceDetector.Browsers;

public class Browser(string name, Version version) : IBrowser
{
    public string Name { get; } = name;

    public Version Version { get; } = version;

    public override string ToString()
    {
        return $"{Name}-{Version}";
    }
}
