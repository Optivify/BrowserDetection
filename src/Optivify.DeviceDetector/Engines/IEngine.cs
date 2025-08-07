namespace Optivify.DeviceDetector.Engines;

public interface IEngine
{
    string Name { get; }

    Version Version { get; }
}
