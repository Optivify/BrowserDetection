namespace Optivify.DeviceDetector.Capabilities;

public interface ICapability
{
    /// <summary>
    /// Capability name
    /// </summary>
    string Name { get; }

    /// <summary>
    /// Checks if the given browser supports this capability.
    /// </summary>
    bool IsSupported(string browserName, Version browserVersion);
}
