using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Optivify.BrowserDetection.Browsers.Detectors;
using Optivify.BrowserDetection.ClientHints.Browsers;
using Optivify.BrowserDetection.ClientHints.Devices;
using Optivify.BrowserDetection.ClientHints.Engines;
using Optivify.BrowserDetection.DeviceArchitectures.Detectors;
using Optivify.BrowserDetection.DeviceOperatingSystems.Detectors;
using Optivify.BrowserDetection.DeviceTypes.Detectors;
using Optivify.BrowserDetection.Engines.Detectors;
using Optivify.BrowserDetection.Platforms.Detectors;

namespace Optivify.BrowserDetection.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static IDetectionBuilder AddBrowserDetection(this IServiceCollection services, IConfiguration configuration)
    {
        var section = configuration.GetSection(BrowserDetectionOptions.ConfigurationSectionName);
        var options = section.Get<BrowserDetectionOptions>() ?? new BrowserDetectionOptions();

        // Configure IOptions
        services.Configure<BrowserDetectionOptions>(section);

        return services.AddBrowserDetection(options);
    }

    public static IDetectionBuilder AddBrowserDetection(this IServiceCollection services, BrowserDetectionOptions options)
    {
        services.AddSingleton(options);

        var builder = new DetectionBuilder(services);

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

        return builder;
    }
}
