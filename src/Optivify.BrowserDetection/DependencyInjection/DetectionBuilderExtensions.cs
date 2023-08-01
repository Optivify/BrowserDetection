using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Optivify.BrowserDetection.Browsers.Detectors;
using Optivify.BrowserDetection.ClientHints;
using Optivify.BrowserDetection.ClientHints.Browsers;
using Optivify.BrowserDetection.ClientHints.Devices;
using Optivify.BrowserDetection.ClientHints.Engines;
using Optivify.BrowserDetection.DetectionData;
using Optivify.BrowserDetection.DeviceArchitectures.Detectors;
using Optivify.BrowserDetection.DeviceOperatingSystems.Detectors;
using Optivify.BrowserDetection.DeviceTypes.Detectors;
using Optivify.BrowserDetection.Engines.Detectors;
using Optivify.BrowserDetection.Platforms.Detectors;
using Optivify.BrowserDetection.Services;
using Optivify.BrowserDetection.UserAgents;

namespace Optivify.BrowserDetection.DependencyInjection;

public static class DetectionBuilderExtensions
{
    #region Client Hints User Agent Resolver

    public static IDetectionBuilder AddClientHintsResolver(this IDetectionBuilder builder)
    {
        builder.Services.AddScoped<IClientHintsResolver, AspNetCoreClientHintsResolver>();

        return builder;
    }

    #endregion

    #region Client Hints Engine Detector

    public static IDetectionBuilder AddClientHintsEngineDetector<TEngineDetector>(this IDetectionBuilder builder)
        where TEngineDetector : class, IClientHintsEngineDetector
    {
        builder.Services.AddSingleton<IClientHintsEngineDetector, TEngineDetector>();

        return builder;
    }

    #endregion

    #region Client Hints Browser Detector

    public static IDetectionBuilder AddClientHintsBrowserDetector<TBrowserDetector>(this IDetectionBuilder builder)
        where TBrowserDetector : class, IClientHintsBrowserDetector
    {
        builder.Services.AddSingleton<IClientHintsBrowserDetector, TBrowserDetector>();

        return builder;
    }

    #endregion

    #region Client Hints Device Detector

    public static IDetectionBuilder AddClientHintsDeviceDetector<TDeviceDetector>(this IDetectionBuilder builder)
        where TDeviceDetector : class, IClientHintsDeviceDetector
    {
        builder.Services.AddSingleton<IClientHintsDeviceDetector, TDeviceDetector>();

        return builder;
    }

    #endregion

    #region Detection Data Loader

    public static IDetectionBuilder AddDetectionDataLoader(this IDetectionBuilder builder)
    {
        builder.Services.AddSingleton<IDetectionDataLoader, DetectionDataLoader>();

        return builder;
    }

    #endregion

    #region User Agent Resolver

    public static IDetectionBuilder AddUserAgentResolver(this IDetectionBuilder builder)
    {
        builder.Services.AddScoped<IUserAgentResolver, AspNetCoreUserAgentResolver>();

        return builder;
    }

    #endregion

    #region Engine Detector

    public static IDetectionBuilder AddEngineDetector<TEngineDetector>(this IDetectionBuilder builder)
        where TEngineDetector : class, IEngineDetector
    {
        builder.Services.TryAddEnumerable(ServiceDescriptor.Singleton<IEngineDetector, TEngineDetector>());

        return builder;
    }

    #endregion

    #region Browser Detector

    public static IDetectionBuilder AddBrowserDetector<TBrowserDetector>(this IDetectionBuilder builder)
        where TBrowserDetector : class, IBrowserDetector
    {
        builder.Services.TryAddEnumerable(ServiceDescriptor.Singleton<IBrowserDetector, TBrowserDetector>());

        return builder;
    }

    #endregion

    #region Platform Detector

    public static IDetectionBuilder AddPlatformDetector<TPlatformDetector>(this IDetectionBuilder builder)
        where TPlatformDetector : class, IPlatformDetector
    {
        builder.Services.TryAddEnumerable(ServiceDescriptor.Singleton<IPlatformDetector, TPlatformDetector>());

        return builder;
    }

    #endregion

    #region Device Type Detector

    public static IDetectionBuilder AddDeviceTypeDetector<TDeviceTypeDetector>(this IDetectionBuilder builder)
        where TDeviceTypeDetector : class, IDeviceTypeDetector
    {
        builder.Services.TryAddEnumerable(ServiceDescriptor.Singleton<IDeviceTypeDetector, TDeviceTypeDetector>());

        return builder;
    }

    #endregion

    #region Device Operating System Detector

    public static IDetectionBuilder AddOperatingSystemDetector<TDeviceOperatingSystemDetector>(this IDetectionBuilder builder)
        where TDeviceOperatingSystemDetector : class, IDeviceOperatingSystemDetector
    {
        builder.Services.TryAddEnumerable(ServiceDescriptor.Singleton<IDeviceOperatingSystemDetector, TDeviceOperatingSystemDetector>());

        return builder;
    }

    #endregion

    #region Device Architecture Detector

    public static IDetectionBuilder AddArchitectureDetector<TDeviceArchitectureDetector>(this IDetectionBuilder builder)
        where TDeviceArchitectureDetector : class, IDeviceArchitectureDetector
    {
        builder.Services.TryAddEnumerable(ServiceDescriptor.Singleton<IDeviceArchitectureDetector, TDeviceArchitectureDetector>());

        return builder;
    }

    #endregion

    #region Detection Service

    public static IDetectionBuilder AddDetectionService(this IDetectionBuilder builder)
    {
        builder.Services.AddScoped<IDetectionService, DetectionService>();

        return builder;
    }

    #endregion
}
