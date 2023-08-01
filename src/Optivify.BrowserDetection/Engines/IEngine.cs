namespace Optivify.BrowserDetection.Engines;

public interface IEngine
{
    string Name { get; }

    Version Version { get; }
}
