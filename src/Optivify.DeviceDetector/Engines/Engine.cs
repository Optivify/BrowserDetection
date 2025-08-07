namespace Optivify.DeviceDetector.Engines;

public class Engine(string name, Version version) : IEngine
{
    public string Name { get; } = name;

    public Version Version { get; } = version;
}
