using Microsoft.Extensions.DependencyInjection;
using Optivify.DeviceDetector.Browsers.Detectors;
using Optivify.DeviceDetector.Capabilities;
using Optivify.DeviceDetector.ClientHints.Browsers;
using Optivify.DeviceDetector.ClientHints.Devices;
using Optivify.DeviceDetector.ClientHints.Engines;
using Optivify.DeviceDetector.DeviceArchitectures.Detectors;
using Optivify.DeviceDetector.DeviceOperatingSystems.Detectors;
using Optivify.DeviceDetector.DeviceTypes.Detectors;
using Optivify.DeviceDetector.Engines.Detectors;
using Optivify.DeviceDetector.Platforms.Detectors;

namespace Optivify.DeviceDetector;

public static class ServiceCollectionExtensions
{
    public static DeviceDetectorBuilder AddDeviceDetector(this IServiceCollection services, Action<DeviceDetectorOptions>? configureAction = null)
    {
        var builder = new DeviceDetectorBuilder(services);

        if (configureAction is not null)
        {
            services.Configure(configureAction);
        }

        services
            .AddOptions<DeviceDetectorOptions>()
            .BindConfiguration(DeviceDetectorOptions.ConfigurationSectionName);

        builder
            .AddClientHintsResolver()
            .AddUserAgentResolver()
            .AddDetectionDataLoader()
            .AddDetectionService()

            // Client hints
            .AddClientHintsEngineDetector<ClientHintsEngineDetector>()
            .AddClientHintsBrowserDetector<ClientHintsBrowserDetector>()
            .AddClientHintsDeviceDetector<ClientHintsDeviceDetector>()

            // Engine detectors
            .AddEngineDetector<BlinkEngineDetector>()
            .AddEngineDetector<WebKitEngineDetector>()
            .AddEngineDetector<GeckoEngineDetector>()

            // Browser detectors
            .AddBrowserDetector<EdgeBrowserDetector>()
            .AddBrowserDetector<ChromeBrowserDetector>()
            .AddBrowserDetector<SafariBrowserDetector>()
            .AddBrowserDetector<SamsungBrowserDetector>()
            .AddBrowserDetector<FirefoxBrowserDetector>()
            .AddBrowserDetector<OperaBrowserDetector>()

            // Platform detectors
            .AddPlatformDetector<AndroidPlatformDetector>()
            .AddPlatformDetector<iPadPlatformDetector>()
            .AddPlatformDetector<iPhonePlatformDetector>()
            .AddPlatformDetector<LinuxPlatformDetector>()
            .AddPlatformDetector<MacintoshPlatformDetector>()
            .AddPlatformDetector<WindowsPlatformDetector>()

            // Device detectors
            .AddDeviceTypeDetector<MobileDeviceDetector>()
            .AddDeviceTypeDetector<DesktopDeviceDetector>()
            .AddDeviceTypeDetector<TabletDeviceDetector>()
            .AddDeviceTypeDetector<BotDeviceDetector>()
            .AddDeviceTypeDetector<MobileBotDeviceDetector>()

            // Operating System detectors
            .AddOperatingSystemDetector<AndroidDetector>()
            .AddOperatingSystemDetector<iOSDetector>()
            .AddOperatingSystemDetector<LinuxDetector>()
            .AddOperatingSystemDetector<MacintoshDetector>()
            .AddOperatingSystemDetector<WindowsDetector>()

            // Architecture detectors
            .AddArchitectureDetector<ARMArchitectureDetector>()
            .AddArchitectureDetector<x86_64ArchitectureDetector>()
            .AddArchitectureDetector<x86ArchitectureDetector>();

        builder
            .ConfigureCapabilityServices()
            .ConfigureBuiltinCapabilities();

        return builder;
    }
}
