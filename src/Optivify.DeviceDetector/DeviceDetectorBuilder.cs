using Microsoft.Extensions.DependencyInjection;

namespace Optivify.DeviceDetector;

public class DeviceDetectorBuilder(IServiceCollection services)
{
    public IServiceCollection Services { get; } = services;
}
