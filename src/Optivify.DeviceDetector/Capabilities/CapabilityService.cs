using Optivify.DeviceDetector.Services;

namespace Optivify.DeviceDetector.Capabilities;

public class CapabilityService(ICapabilityRegistry capabilityRegistry, IDetectionService detectionService) : ICapabilityService
{
    public bool HasCapability<TCapability>()
    {
        if (!capabilityRegistry.TryGetCapability<TCapability>(out var capability) ||
            capability is null)
        {
            return false;
        }

        return capability.IsSupported(detectionService.Browser.Name, detectionService.Browser.Version);
    }
}