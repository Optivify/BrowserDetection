namespace Optivify.DeviceDetector.Capabilities;

public interface ICapabilityRegistry
{
    bool TryGetCapability<TCapabilityType>(out ICapability? capability);
}

public class CapabilityRegistry(IEnumerable<ICapability> capabilities) : ICapabilityRegistry
{
    private readonly Dictionary<Type, ICapability> _capabilities = capabilities.ToDictionary(capability => capability.GetType(), capability => capability);

    public bool TryGetCapability<TCapabilityType>(out ICapability? capability)
    {
        return _capabilities.TryGetValue(typeof(TCapabilityType), out capability);
    }
}