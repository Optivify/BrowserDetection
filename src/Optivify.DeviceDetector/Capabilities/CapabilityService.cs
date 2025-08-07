using Optivify.DeviceDetector.Services;

namespace Optivify.DeviceDetector.Capabilities;

public  class CapabilityService(ICapabilityRegistry capabilityRegistry, IDetectionService detectionService) : ICapabilityService
{
    public bool HasCapability(string capabilityName)
    {
        if (!capabilityRegistry.TryGetCapability(capabilityName, out var capability) ||
            capability is null)
        {
            return false;
        }

        return capability.IsSupported(detectionService.Browser.Name, detectionService.Browser.Version);
    }
}