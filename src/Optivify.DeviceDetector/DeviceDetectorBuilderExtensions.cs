using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Optivify.DeviceDetector.Browsers.Detectors;
using Optivify.DeviceDetector.ClientHints;
using Optivify.DeviceDetector.ClientHints.Browsers;
using Optivify.DeviceDetector.ClientHints.Devices;
using Optivify.DeviceDetector.ClientHints.Engines;
using Optivify.DeviceDetector.DetectionData;
using Optivify.DeviceDetector.DeviceArchitectures.Detectors;
using Optivify.DeviceDetector.DeviceOperatingSystems.Detectors;
using Optivify.DeviceDetector.DeviceTypes.Detectors;
using Optivify.DeviceDetector.Engines.Detectors;
using Optivify.DeviceDetector.Platforms.Detectors;
using Optivify.DeviceDetector.Services;
using Optivify.DeviceDetector.UserAgents;

namespace Optivify.DeviceDetector;

public static class DeviceDetectorBuilderExtensions
{
    #region Client Hints User Agent Resolver

    public static DeviceDetectorBuilder AddClientHintsResolver(this DeviceDetectorBuilder builder)
    {
        builder.Services.AddScoped<IClientHintsResolver, AspNetCoreClientHintsResolver>();

        return builder;
    }

    #endregion

    #region Client Hints Engine Detector

    public static DeviceDetectorBuilder AddClientHintsEngineDetector<TEngineDetector>(this DeviceDetectorBuilder builder)
        where TEngineDetector : class, IClientHintsEngineDetector
    {
        builder.Services.AddSingleton<IClientHintsEngineDetector, TEngineDetector>();

        return builder;
    }

    #endregion

    #region Client Hints Browser Detector

    public static DeviceDetectorBuilder AddClientHintsBrowserDetector<TBrowserDetector>(this DeviceDetectorBuilder builder)
        where TBrowserDetector : class, IClientHintsBrowserDetector
    {
        builder.Services.AddSingleton<IClientHintsBrowserDetector, TBrowserDetector>();

        return builder;
    }

    #endregion

    #region Client Hints Device Detector

    public static DeviceDetectorBuilder AddClientHintsDeviceDetector<TDeviceDetector>(this DeviceDetectorBuilder builder)
        where TDeviceDetector : class, IClientHintsDeviceDetector
    {
        builder.Services.AddSingleton<IClientHintsDeviceDetector, TDeviceDetector>();

        return builder;
    }

    #endregion

    #region Detection Data Loader

    public static DeviceDetectorBuilder AddDetectionDataLoader(this DeviceDetectorBuilder builder)
    {
        builder.Services.AddSingleton<IDetectionDataLoader, DetectionDataLoader>();

        return builder;
    }

    #endregion

    #region User Agent Resolver

    public static DeviceDetectorBuilder AddUserAgentResolver(this DeviceDetectorBuilder builder)
    {
        builder.Services.AddScoped<IUserAgentResolver, AspNetCoreUserAgentResolver>();

        return builder;
    }

    #endregion

    #region Engine Detector

    public static DeviceDetectorBuilder AddEngineDetector<TEngineDetector>(this DeviceDetectorBuilder builder)
        where TEngineDetector : class, IEngineDetector
    {
        builder.Services.TryAddEnumerable(ServiceDescriptor.Singleton<IEngineDetector, TEngineDetector>());

        return builder;
    }

    #endregion

    #region Browser Detector

    public static DeviceDetectorBuilder AddBrowserDetector<TBrowserDetector>(this DeviceDetectorBuilder builder)
        where TBrowserDetector : class, IBrowserDetector
    {
        builder.Services.TryAddEnumerable(ServiceDescriptor.Singleton<IBrowserDetector, TBrowserDetector>());

        return builder;
    }

    #endregion

    #region Platform Detector

    public static DeviceDetectorBuilder AddPlatformDetector<TPlatformDetector>(this DeviceDetectorBuilder builder)
        where TPlatformDetector : class, IPlatformDetector
    {
        builder.Services.TryAddEnumerable(ServiceDescriptor.Singleton<IPlatformDetector, TPlatformDetector>());

        return builder;
    }

    #endregion

    #region Device Type Detector

    public static DeviceDetectorBuilder AddDeviceTypeDetector<TDeviceTypeDetector>(this DeviceDetectorBuilder builder)
        where TDeviceTypeDetector : class, IDeviceTypeDetector
    {
        builder.Services.TryAddEnumerable(ServiceDescriptor.Singleton<IDeviceTypeDetector, TDeviceTypeDetector>());

        return builder;
    }

    #endregion

    #region Device Operating System Detector

    public static DeviceDetectorBuilder AddOperatingSystemDetector<TDeviceOperatingSystemDetector>(this DeviceDetectorBuilder builder)
        where TDeviceOperatingSystemDetector : class, IDeviceOperatingSystemDetector
    {
        builder.Services.TryAddEnumerable(ServiceDescriptor.Singleton<IDeviceOperatingSystemDetector, TDeviceOperatingSystemDetector>());

        return builder;
    }

    #endregion

    #region Device Architecture Detector

    public static DeviceDetectorBuilder AddArchitectureDetector<TDeviceArchitectureDetector>(this DeviceDetectorBuilder builder)
        where TDeviceArchitectureDetector : class, IDeviceArchitectureDetector
    {
        builder.Services.TryAddEnumerable(ServiceDescriptor.Singleton<IDeviceArchitectureDetector, TDeviceArchitectureDetector>());

        return builder;
    }

    #endregion

    #region Detection Service

    public static DeviceDetectorBuilder AddDetectionService(this DeviceDetectorBuilder builder)
    {
        builder.Services.AddScoped<IDetectionService, DetectionService>();

        return builder;
    }

    #endregion
}
