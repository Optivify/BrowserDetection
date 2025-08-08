using System.Text.RegularExpressions;
using Microsoft.Extensions.Options;
using Optivify.DeviceDetector.Bots;
using Optivify.DeviceDetector.Bots.Detectors;
using Optivify.DeviceDetector.Browsers;
using Optivify.DeviceDetector.Browsers.Detectors;
using Optivify.DeviceDetector.ClientHints;
using Optivify.DeviceDetector.ClientHints.Browsers;
using Optivify.DeviceDetector.ClientHints.Devices;
using Optivify.DeviceDetector.ClientHints.Engines;
using Optivify.DeviceDetector.DeviceArchitectures;
using Optivify.DeviceDetector.DeviceArchitectures.Detectors;
using Optivify.DeviceDetector.DeviceOperatingSystems;
using Optivify.DeviceDetector.DeviceOperatingSystems.Detectors;
using Optivify.DeviceDetector.DeviceTypes;
using Optivify.DeviceDetector.DeviceTypes.Detectors;
using Optivify.DeviceDetector.Engines;
using Optivify.DeviceDetector.Engines.Detectors;
using Optivify.DeviceDetector.Platforms;
using Optivify.DeviceDetector.Platforms.Detectors;
using Optivify.DeviceDetector.UserAgents;

namespace Optivify.DeviceDetector.Services;

public class DetectionService : IDetectionService
{
    private static readonly Regex _platformRegex = new(@"\(([^()]*)\)", RegexOptions.Compiled);

    public DeviceDetectorOptions DeviceDetectorOptions { get; protected set; }

    private readonly IClientHintsEngineDetector _clientHintsEngineDetector;

    private readonly IClientHintsBrowserDetector _clientHintsBrowserDetector;

    private readonly IClientHintsDeviceDetector _clientHintsDeviceDetector;

    #region Client Hints Resolver

    private readonly Lazy<IClientHintsResolver> _clientHintsResolver;

    public IClientHintsResolver ClientHintsResolver => _clientHintsResolver.Value;

    #endregion

    #region User Agent Resolver

    private readonly Lazy<IUserAgentResolver> _userAgentResolver;

    public IUserAgentResolver UserAgentResolver => _userAgentResolver.Value;

    #endregion

    #region Client Hints Device Pixel Ratio

    private readonly Lazy<double?> _clientHintDevicePixelRatio;

    public double? DevicePixelRatio => _clientHintDevicePixelRatio.Value;

    #endregion

    #region Client Hints Model

    private readonly Lazy<string?> _clientHintModel;

    public string? Model => _clientHintModel.Value;

    #endregion

    #region Client Hints Viewport Width

    private readonly Lazy<int?> _clientHintViewportWidth;

    public int? ViewportWidth => _clientHintViewportWidth.Value;

    #endregion

    #region Client Hints Viewport Height

    private readonly Lazy<int?> _clientHintViewportHeight;

    public int? ViewportHeight => _clientHintViewportHeight.Value;

    #endregion

    #region Bot

    private readonly IEnumerable<IBotDetector> _botDetectors;

    private readonly Lazy<IBot?> _bot;

    public IBot? Bot => _bot.Value;

    public bool IsBot => _bot.Value is not null;

    #endregion

    #region Engine

    private readonly IEnumerable<IEngineDetector> _engineDetectors;

    private readonly Lazy<IEngine> _engine;

    public IEngine Engine => _engine.Value;

    #endregion

    #region Browser

    private readonly IEnumerable<IBrowserDetector> _browserDetectors;

    private readonly Lazy<IBrowser> _browser;

    public IBrowser Browser => _browser.Value;

    #endregion

    #region Platform

    private readonly IEnumerable<IPlatformDetector> _platformDetectors;

    private readonly Lazy<IPlatform> _platform;

    public IPlatform Platform => _platform.Value;

    #endregion

    #region Device

    private readonly IEnumerable<IDeviceTypeDetector> _deviceDetectors;

    private readonly Lazy<IDeviceType> _device;

    public IDeviceType Device => _device.Value;

    #endregion

    #region Operating System

    private readonly IEnumerable<IDeviceOperatingSystemDetector> _operatingSystemDetectors;

    private readonly Lazy<IDeviceOperatingSystem> _operatingSystem;

    public IDeviceOperatingSystem OperatingSystem => _operatingSystem.Value;

    #endregion

    #region Architecture

    private readonly IEnumerable<IDeviceArchitectureDetector> _architectureDetectors;

    private readonly Lazy<IDeviceArchitecture> _architecture;

    public IDeviceArchitecture Architecture => _architecture.Value;

    #endregion

    public DetectionService(
        IOptions<DeviceDetectorOptions> options,

        IClientHintsEngineDetector clientHintsEngineDetector,
        IClientHintsBrowserDetector clientHintsBrowserDetector,
        IClientHintsDeviceDetector clientHintsDeviceDetector,

        IClientHintsResolver clientHintsResolver,
        IUserAgentResolver userAgentResolver,

        IEnumerable<IBotDetector> botDetectors,
        IEnumerable<IEngineDetector> engineDetectors,
        IEnumerable<IBrowserDetector> browserDetectors,
        IEnumerable<IPlatformDetector> platformDetectors,
        IEnumerable<IDeviceTypeDetector> deviceDetectors,
        IEnumerable<IDeviceOperatingSystemDetector> operatingSystemDetectors,
        IEnumerable<IDeviceArchitectureDetector> architectureDetectors
    )
    {
        DeviceDetectorOptions = options.Value;

        _clientHintsEngineDetector = clientHintsEngineDetector;
        _clientHintsBrowserDetector = clientHintsBrowserDetector;
        _clientHintsDeviceDetector = clientHintsDeviceDetector;

        _clientHintsResolver = new Lazy<IClientHintsResolver>(() => clientHintsResolver);

        _userAgentResolver = new Lazy<IUserAgentResolver>(() => userAgentResolver);

        _clientHintDevicePixelRatio = new Lazy<double?>(() => ClientHintsResolver.DevicePixelRatio);
        _clientHintModel = new Lazy<string?>(() => ClientHintsResolver.UserAgentModel);
        _clientHintViewportWidth = new Lazy<int?>(() => ClientHintsResolver.ViewportWidth);
        _clientHintViewportHeight = new Lazy<int?>(() => ClientHintsResolver.ViewportHeight);

        _botDetectors = botDetectors;
        _bot = new Lazy<IBot?>(GetBot);

        _engineDetectors = engineDetectors;
        _engine = new Lazy<IEngine>(GetEngine);

        _browserDetectors = browserDetectors;
        _browser = new Lazy<IBrowser>(GetBrowser);

        _platformDetectors = platformDetectors;
        _platform = new Lazy<IPlatform>(GetPlatform);

        _deviceDetectors = deviceDetectors;
        _device = new Lazy<IDeviceType>(GetDevice);

        _operatingSystemDetectors = operatingSystemDetectors;
        _operatingSystem = new Lazy<IDeviceOperatingSystem>(GetOperatingSystem);

        _architectureDetectors = architectureDetectors;
        _architecture = new Lazy<IDeviceArchitecture>(GetArchitecture);
    }

    /// <summary>
    /// Use this method to set the Browser Insights options manually.
    /// </summary>
    /// <param name="deviceDetectorOptions">The custom Browser Insights options.</param>
    public void SetOptions(DeviceDetectorOptions deviceDetectorOptions)
    {
        DeviceDetectorOptions = deviceDetectorOptions;
    }

    protected virtual string GetPlatformString(string? userAgent)
    {
        if (userAgent is null)
        {
            return string.Empty;
        }

        var matches = _platformRegex.Matches(userAgent);

        if (matches.Count <= 0)
        {
            return string.Empty;
        }

        var match = matches[0];

        return match.Groups.Count > 1 ? match.Groups[1].Value : string.Empty;
    }

    protected virtual IBot? GetBot()
    {
        foreach (var botDetector in _botDetectors.OrderBy(x => x.Order))
        {
            if (botDetector.TryParse(UserAgentResolver.UserAgent, out var detectedBot))
            {
                return detectedBot;
            }
        }

        return null;
    }

    protected virtual IEngine GetEngine()
    {
        if (!DeviceDetectorOptions.SkipClientHintsDetection &&
            !string.IsNullOrEmpty(ClientHintsResolver.UserAgentFullVersionList))
        {
            if (!string.IsNullOrEmpty(ClientHintsResolver.UserAgentFullVersionList))
            {
                var clientHintsEngine = _clientHintsEngineDetector.GetEngine(ClientHintsResolver.UserAgentFullVersionList);

                if (clientHintsEngine is not null)
                {
                    return clientHintsEngine;
                }
            }
        }

        foreach (var engineDetector in _engineDetectors.OrderBy(x => x.Order))
        {
            if (engineDetector.TryParse(Browser, OperatingSystem, UserAgentResolver.UserAgent, out var detectedEngine))
            {
                return detectedEngine;
            }
        }

        return new Engine(EngineNames.Others, new Version());
    }

    protected virtual IBrowser GetBrowser()
    {
        if (!DeviceDetectorOptions.SkipClientHintsDetection &&
            !string.IsNullOrEmpty(ClientHintsResolver.UserAgentFullVersionList))
        {
            var clientHintsBrowser = _clientHintsBrowserDetector.GetBrowser(ClientHintsResolver.UserAgentFullVersionList);

            if (clientHintsBrowser is not null)
            {
                return clientHintsBrowser;
            }
        }

        foreach (var browserDetector in _browserDetectors.OrderBy(x => x.Order))
        {
            if (browserDetector.TryParse(UserAgentResolver.UserAgent, out var detectedBrowser))
            {
                return detectedBrowser;
            }
        }

        return new Browser(BrowserNames.Others, new Version());
    }

    protected virtual IPlatform GetPlatform()
    {
        var platformString = GetPlatformString(UserAgentResolver.UserAgent);

        foreach (var platformDetector in _platformDetectors.OrderBy(x => x.Order))
        {
            if (platformDetector.TryParse(platformString, out var detectedPlatform))
            {
                return detectedPlatform;
            }
        }

        return new Platform(platformString, PlatformNames.Others);
    }

    protected virtual IDeviceType GetDevice()
    {
        if (!DeviceDetectorOptions.SkipClientHintsDetection)
        {
            if (!string.IsNullOrEmpty(ClientHintsResolver.UserAgentMobile))
            {
                var clientHintsDevice = _clientHintsDeviceDetector.GetDevice(ClientHintsResolver.UserAgentMobile);

                if (clientHintsDevice is not null)
                {
                    return clientHintsDevice;
                }
            }
        }

        foreach (var deviceDetector in _deviceDetectors.OrderBy(x => x.Order))
        {
            if (deviceDetector.TryParse(Platform, UserAgentResolver.UserAgent, out var detectedPlatform))
            {
                return detectedPlatform;
            }
        }

        return new DeviceType(DeviceTypeNames.Others);
    }

    protected virtual IDeviceOperatingSystem GetOperatingSystem()
    {
        if (ClientHintsResolver.UserAgentPlatform is not null)
        {
            var userAgentPlatform = ClientHintsResolver.UserAgentPlatform.Trim('"');
            var version = ClientHintsResolver.UserAgentPlatformVersion ?? new Version();

            return new DeviceOperatingSystem(userAgentPlatform, version);
        }

        foreach (var operatingSystemDetector in _operatingSystemDetectors.OrderBy(x => x.Order))
        {
            if (operatingSystemDetector.TryParse(Platform, UserAgentResolver.UserAgent, out var detectedOperatingSystem))
            {
                return detectedOperatingSystem;
            }
        }

        return new DeviceOperatingSystem(DeviceOperatingSystemNames.Others, new Version());
    }

    protected virtual IDeviceArchitecture GetArchitecture()
    {
        foreach (var architectureDetector in _architectureDetectors.OrderBy(x => x.Order))
        {
            if (architectureDetector.TryParse(UserAgentResolver.UserAgent, out var detectedArchitecture))
            {
                return detectedArchitecture;
            }
        }

        return new DeviceArchitecture(DeviceArchitectureNames.Others);
    }
}
