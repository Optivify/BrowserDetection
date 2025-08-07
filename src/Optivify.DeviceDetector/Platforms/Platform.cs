namespace Optivify.DeviceDetector.Platforms;

public class Platform(string platformString, string name) : IPlatform
{
    public string PlatformString { get; } = platformString;

    public string Name { get; } = name;

    public override string ToString()
    {
        return Name;
    }
}
