using BenchmarkDotNet.Attributes;
using Microsoft.Extensions.Options;
using Moq;
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

namespace Optivify.DeviceDetector.Benchmark;

public class DetectionServiceBenchmarks
{
    public const string ClientHintsUserAgentChromeOnWindows11 = "\"Chromium\";v=\"106\", \"Google Chrome\";v=\"106\", \"Not;A=Brand\";v=\"99\"";

    public const string ClientHintsUserAgentSafariOniOS = "";

    public const string UserAgentChromeOnWindows10 = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/70.0.3538.77 Safari/537.36";

    public const string UserAgentSafariOniOS = "Mozilla/5.0 (iPhone; CPU iPhone OS 15_5 like Mac OS X) AppleWebKit/605.1.15 (KHTML, like Gecko) Version/15.4 Mobile/15E148 Safari/604.1";

    private readonly DetectionDataLoader _detectionDataLoader = new();

    private readonly ClientHintsEngineDetector _clientHintsEngineDetector;

    private readonly ClientHintsBrowserDetector _clientHintsBrowserDetector;

    private readonly ClientHintsDeviceDetector _clientHintsDeviceDetector;

    private readonly IEngineDetector[] _engineDetectors;

    private readonly IBrowserDetector[] _browserDetectors;

    private readonly IPlatformDetector[] _platformDetectors;

    private readonly IDeviceTypeDetector[] _deviceDetectors;

    private readonly IDeviceOperatingSystemDetector[] _operatingSystemDetectors;

    private readonly IDeviceArchitectureDetector[] _architectureDetectors;

    private readonly IDetectionService _detectionServiceChromeOnWindows10;

    private readonly IDetectionService _detectionServiceSafariOniOs;

    public DetectionServiceBenchmarks()
    {
        _clientHintsEngineDetector = new ClientHintsEngineDetector();
        _clientHintsBrowserDetector = new ClientHintsBrowserDetector();
        _clientHintsDeviceDetector = new ClientHintsDeviceDetector();

        _engineDetectors =
        [
            new BlinkEngineDetector(_detectionDataLoader),
            new WebKitEngineDetector(_detectionDataLoader),
            new GeckoEngineDetector(_detectionDataLoader)
        ];

        _browserDetectors =
        [
            new EdgeBrowserDetector(_detectionDataLoader),
            new ChromeBrowserDetector(_detectionDataLoader),
            new SafariBrowserDetector(_detectionDataLoader)
        ];

        _platformDetectors =
        [
            new AndroidPlatformDetector(_detectionDataLoader),
            new iPadPlatformDetector(_detectionDataLoader),
            new iPhonePlatformDetector(_detectionDataLoader),
            new LinuxPlatformDetector(_detectionDataLoader),
            new MacintoshPlatformDetector(_detectionDataLoader),
            new WindowsPlatformDetector(_detectionDataLoader)
        ];

        _deviceDetectors =
        [
            new DesktopDeviceDetector(_detectionDataLoader),
            new MobileDeviceDetector(_detectionDataLoader),
            new TabletDeviceDetector(_detectionDataLoader)
        ];

        _operatingSystemDetectors =
        [
            new AndroidDetector(_detectionDataLoader),
            new iOSDetector(_detectionDataLoader),
            new LinuxDetector(_detectionDataLoader),
            new MacintoshDetector(_detectionDataLoader),
            new WindowsDetector(_detectionDataLoader)
        ];

        _architectureDetectors =
        [
            new ARMArchitectureDetector(_detectionDataLoader),
            new x86_64ArchitectureDetector(_detectionDataLoader),
            new x86ArchitectureDetector(_detectionDataLoader)
        ];

        _detectionServiceChromeOnWindows10 = GetService(ClientHintsUserAgentChromeOnWindows11, UserAgentChromeOnWindows10);
        _detectionServiceSafariOniOs = GetService(ClientHintsUserAgentSafariOniOS, UserAgentSafariOniOS);
    }

    private static IClientHintsResolver GetMockClientHintsResolver(string clientHintsUserAgent)
    {
        var mockClientHintsResolver = new Mock<IClientHintsResolver>();
        mockClientHintsResolver.Setup(a => a.UserAgent).Returns(clientHintsUserAgent);

        return mockClientHintsResolver.Object;
    }

    public IDetectionService GetService(string clientHintsUserAgent, string userAgent)
    {
        var mockUserAgentResolver = new Mock<IUserAgentResolver>();
        mockUserAgentResolver.Setup(a => a.UserAgent).Returns(userAgent);

        return new DetectionService(
            Options.Create(new DeviceDetectorOptions()),
            _clientHintsEngineDetector,
            _clientHintsBrowserDetector,
            _clientHintsDeviceDetector,

            GetMockClientHintsResolver(clientHintsUserAgent),
            mockUserAgentResolver.Object,
            _engineDetectors,
            _browserDetectors,
            _platformDetectors,
            _deviceDetectors,
            _operatingSystemDetectors,
            _architectureDetectors);
    }

    [Benchmark]
    public string Detect_ChromeOnWindows10_Browser()
    {
        return _detectionServiceChromeOnWindows10.Browser.Name;
    }

    [Benchmark]
    public string Detect_ChromeOnWindows10_Platform()
    {
        return _detectionServiceChromeOnWindows10.Platform.Name;
    }

    [Benchmark]
    public string Detect_SafariOniOS_Browser()
    {
        return _detectionServiceSafariOniOs.Browser.Name;
    }

    [Benchmark]
    public string Detect_SafariOniOS_Platform()
    {
        return _detectionServiceSafariOniOs.Platform.Name;
    }
}