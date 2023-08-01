using Optivify.BrowserDetection.Browsers;
using Optivify.BrowserDetection.Browsers.Detectors;
using Optivify.BrowserDetection.ClientHints;
using Optivify.BrowserDetection.ClientHints.Browsers;
using Optivify.BrowserDetection.ClientHints.Devices;
using Optivify.BrowserDetection.ClientHints.Engines;
using Optivify.BrowserDetection.DeviceArchitectures;
using Optivify.BrowserDetection.DeviceArchitectures.Detectors;
using Optivify.BrowserDetection.DeviceOperatingSystems;
using Optivify.BrowserDetection.DeviceOperatingSystems.Detectors;
using Optivify.BrowserDetection.DeviceTypes;
using Optivify.BrowserDetection.DeviceTypes.Detectors;
using Optivify.BrowserDetection.Engines;
using Optivify.BrowserDetection.Engines.Detectors;
using Optivify.BrowserDetection.Platforms;
using Optivify.BrowserDetection.Platforms.Detectors;
using Optivify.BrowserDetection.UserAgents;
using System.Text.RegularExpressions;

namespace Optivify.BrowserDetection.Services;

public class DetectionService : IDetectionService
{
    private static readonly Regex PlatformRegex = new(@"\(([^()]*)\)", RegexOptions.Compiled);

    private readonly IClientHintsEngineDetector clientHintsEngineDetector;

    private readonly IClientHintsBrowserDetector clientHintsBrowserDetector;

    private readonly IClientHintsDeviceDetector clientHintsDeviceDetector;

    public BrowserDetectionOptions BrowserDetectionOptions { get; protected set; }

    #region Client Hints Resolver

    public Lazy<IClientHintsResolver> clientHintsResolver;

    public IClientHintsResolver ClientHintsResolver => this.clientHintsResolver.Value;

    #endregion

    #region User Agent Resolver

    public Lazy<IUserAgentResolver> userAgentResolver;

    public IUserAgentResolver UserAgentResolver => this.userAgentResolver.Value;

    #endregion

    #region Client Hints Device Pixel Ratio

    public Lazy<double?> devicePixelRatio;

    public double? DevicePixelRatio => this.devicePixelRatio.Value;

    #endregion

    #region Client Hints Model

    public Lazy<string> model;

    public string Model => this.model.Value;

    #endregion

    #region Client Hints Viewport Width

    public Lazy<int?> viewportWidth;

    public int? ViewportWidth => this.viewportWidth.Value;

    #endregion

    #region Client Hints Viewport Height

    public Lazy<int?> viewportHeight;

    public int? ViewportHeight => this.viewportHeight.Value;

    #endregion

    #region Engine

    private readonly IEnumerable<IEngineDetector> engineDetectors;

    private readonly Lazy<IEngine> engine;

    public IEngine Engine => this.engine.Value;

    #endregion

    #region Browser

    private readonly IEnumerable<IBrowserDetector> browserDetectors;

    private readonly Lazy<IBrowser> browser;

    public IBrowser Browser => this.browser.Value;

    #endregion

    #region Platform

    private readonly IEnumerable<IPlatformDetector> platformDetectors;

    private readonly Lazy<IPlatform> platform;

    public IPlatform Platform => this.platform.Value;

    #endregion

    #region Device

    private readonly IEnumerable<IDeviceTypeDetector> deviceDetectors;

    private readonly Lazy<IDeviceType> device;

    public IDeviceType Device => this.device.Value;

    #endregion

    #region Operating System

    private readonly IEnumerable<IDeviceOperatingSystemDetector> operatingSystemDetectors;

    private readonly Lazy<IDeviceOperatingSystem> operatingSystem;

    public IDeviceOperatingSystem OperatingSystem => this.operatingSystem.Value;

    #endregion

    #region Architecture

    private readonly IEnumerable<IDeviceArchitectureDetector> architectureDetectors;

    private readonly Lazy<IDeviceArchitecture> architecture;

    public IDeviceArchitecture Architecture => this.architecture.Value;

    #endregion

    public DetectionService(
        BrowserDetectionOptions options,

        IClientHintsEngineDetector clientHintsEngineDetector,
        IClientHintsBrowserDetector clientHintsBrowserDetector,
        IClientHintsDeviceDetector clientHintsDeviceDetector,

        IClientHintsResolver clientHintsResolver,
        IUserAgentResolver userAgentResolver,

        IEnumerable<IEngineDetector> engineDetectors,
        IEnumerable<IBrowserDetector> browserDetectors,
        IEnumerable<IPlatformDetector> platformDetectors,
        IEnumerable<IDeviceTypeDetector> deviceDetectors,
        IEnumerable<IDeviceOperatingSystemDetector> operatingSystemDetectors,
        IEnumerable<IDeviceArchitectureDetector> architectureDetectors
    )
    {
        this.BrowserDetectionOptions = options;

        this.clientHintsEngineDetector = clientHintsEngineDetector;
        this.clientHintsBrowserDetector = clientHintsBrowserDetector;
        this.clientHintsDeviceDetector = clientHintsDeviceDetector;

        this.clientHintsResolver = new Lazy<IClientHintsResolver>(() => { return clientHintsResolver; });
        this.userAgentResolver = new Lazy<IUserAgentResolver>(() => { return userAgentResolver; });

        this.engineDetectors = engineDetectors;
        this.engine = new Lazy<IEngine>(() => { return this.GetEngine(); });

        this.browserDetectors = browserDetectors;
        this.browser = new Lazy<IBrowser>(() => { return this.GetBrowser(); });

        this.platformDetectors = platformDetectors;
        this.platform = new Lazy<IPlatform>(() => { return this.GetPlatform(); });

        this.deviceDetectors = deviceDetectors;
        this.device = new Lazy<IDeviceType>(() => { return this.GetDevice(); });

        this.operatingSystemDetectors = operatingSystemDetectors;
        this.operatingSystem = new Lazy<IDeviceOperatingSystem>(() => { return this.GetOperatingSystem(); });

        this.architectureDetectors = architectureDetectors;
        this.architecture = new Lazy<IDeviceArchitecture>(() => { return this.GetArchitecture(); });

        this.devicePixelRatio = new Lazy<double?>(() => { return this.ClientHintsResolver.DevicePixelRatio; });
        this.model = new Lazy<string>(() => { return this.ClientHintsResolver.UserAgentModel; });
        this.viewportWidth = new Lazy<int?>(() => { return this.ClientHintsResolver.ViewportWidth; });
        this.viewportHeight = new Lazy<int?>(() => { return this.ClientHintsResolver.ViewportHeight; });
    }

    /// <summary>
    /// Use this method to set the browser detection options manually.
    /// </summary>
    /// <param name="browserDetectionOptions">The custom browser detection options.</param>
    public void SetBrowserDetectionOptions(BrowserDetectionOptions browserDetectionOptions)
    {
        this.BrowserDetectionOptions = browserDetectionOptions;
    }

    protected virtual string GetPlatformString(string? userAgent)
    {
        if (userAgent is null)
        {
            return string.Empty;
        }

        var matches = PlatformRegex.Matches(userAgent);

        if (matches.Count > 0)
        {
            var match = matches[0];

            if (match.Groups.Count > 1)
            {
                return match.Groups[1].Value;
            }
        }

        return string.Empty;
    }

    protected virtual IEngine GetEngine()
    {
        if (!this.BrowserDetectionOptions.SkipClientHintsDetection &&
            !string.IsNullOrEmpty(this.ClientHintsResolver.UserAgentFullVersionList))
        {
            if (!string.IsNullOrEmpty(this.ClientHintsResolver.UserAgentFullVersionList))
            {
                var engine = this.clientHintsEngineDetector.GetEngine(this.ClientHintsResolver.UserAgentFullVersionList);

                if (engine != null)
                {
                    return engine;
                }
            }
        }

        foreach (var engineDetector in this.engineDetectors.OrderBy(x => x.Order))
        {
            if (engineDetector.TryParse(this.Browser, this.OperatingSystem, this.UserAgentResolver.UserAgent, out var engine) && engine != null)
            {
                return engine;
            }
        }

        return new Engine(EngineNames.Others, new Version());
    }

    protected virtual IBrowser GetBrowser()
    {
        if (!this.BrowserDetectionOptions.SkipClientHintsDetection &&
            !string.IsNullOrEmpty(this.ClientHintsResolver.UserAgentFullVersionList))
        {
            var browser = this.clientHintsBrowserDetector.GetBrowser(this.ClientHintsResolver.UserAgentFullVersionList);

            if (browser != null)
            {
                return browser;
            }
        }

        foreach (var browserDetector in this.browserDetectors.OrderBy(x => x.Order))
        {
            if (browserDetector.TryParse(this.UserAgentResolver.UserAgent, out var browser) && browser != null)
            {
                return browser;
            }
        }

        return new Browser(BrowserNames.Others, new Version());
    }

    protected virtual IPlatform GetPlatform()
    {
        var platformString = this.GetPlatformString(this.UserAgentResolver.UserAgent);

        foreach (var platformDetector in this.platformDetectors.OrderBy(x => x.Order))
        {
            if (platformDetector.TryParse(platformString, out var platform) && platform != null)
            {
                return platform;
            }
        }

        return new Platform(platformString, PlatformNames.Others);
    }

    protected virtual IDeviceType GetDevice()
    {
        if (!this.BrowserDetectionOptions.SkipClientHintsDetection)
        {
            if (!string.IsNullOrEmpty(this.ClientHintsResolver.UserAgentMobile))
            {
                var device = this.clientHintsDeviceDetector.GetDevice(this.ClientHintsResolver.UserAgentMobile);

                if (device != null)
                {
                    return device;
                }
            }
        }

        var platform = this.Platform;

        foreach (var deviceDetector in this.deviceDetectors.OrderBy(x => x.Order))
        {
            if (deviceDetector.TryParse(platform, this.UserAgentResolver.UserAgent, out var device) && device != null)
            {
                return device;
            }
        }

        return new DeviceType(DeviceTypeNames.Others);
    }

    protected virtual IDeviceOperatingSystem GetOperatingSystem()
    {
        if (this.ClientHintsResolver.UserAgentPlatform != null)
        {
            var userAgentPlatform = this.ClientHintsResolver.UserAgentPlatform.Trim('"');
            var version = this.ClientHintsResolver.UserAgentPlatformVersion ?? new Version();

            return new DeviceOperatingSystem(userAgentPlatform, version);
        }

        var platform = this.Platform;

        foreach (var operatingSystemDetector in this.operatingSystemDetectors.OrderBy(x => x.Order))
        {
            if (operatingSystemDetector.TryParse(platform, this.UserAgentResolver.UserAgent, out var operatingSystem) && operatingSystem != null)
            {
                return operatingSystem;
            }
        }

        return new DeviceOperatingSystem(DeviceOperatingSystemNames.Others, new Version());
    }

    protected virtual IDeviceArchitecture GetArchitecture()
    {
        var platform = this.Platform;

        foreach (var architectureDetector in this.architectureDetectors.OrderBy(x => x.Order))
        {
            if (architectureDetector.TryParse(this.UserAgentResolver.UserAgent, out var architecture) && architecture != null)
            {
                return architecture;
            }
        }

        return new DeviceArchitecture(DeviceArchitectureNames.Others);
    }
}
