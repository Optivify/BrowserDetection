using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Optivify.DeviceDetector.Capabilities.Avif;

namespace Optivify.DeviceDetector.Capabilities;

public static class DeviceDetectorBuilderExtensions
{
    public static DeviceDetectorBuilder AddBrowserCapability<TCapability>(this DeviceDetectorBuilder builder) where TCapability : class, ICapability
    {
        builder.Services.TryAddEnumerable(ServiceDescriptor.Singleton<ICapability, TCapability>());

        return builder;
    }

    internal static DeviceDetectorBuilder ConfigureCapabilityServices(this DeviceDetectorBuilder builder)
    {
        builder.Services.AddSingleton<ICapabilityRegistry, CapabilityRegistry>();
        builder.Services.AddScoped<ICapabilityService, CapabilityService>();

        return builder;
    }

    internal static DeviceDetectorBuilder ConfigureBuiltinCapabilities(this DeviceDetectorBuilder builder)
    {
        builder.AddBrowserCapability<AvifCapability>();

        return builder;
    }
}
