namespace Optivify.DeviceDetector.Capabilities;

public interface ICapabilityRegistry
{
    bool TryGetCapability(string name, out ICapability? capability);
}

public class CapabilityRegistry(IEnumerable<ICapability> capabilities) : ICapabilityRegistry
{
    private readonly Dictionary<string, ICapability> _capabilities = capabilities.ToDictionary(x => x.Name, x => x, StringComparer.OrdinalIgnoreCase);

    public bool TryGetCapability(string name, out ICapability? capability)
    {
        return _capabilities.TryGetValue(name, out capability);
    }
}