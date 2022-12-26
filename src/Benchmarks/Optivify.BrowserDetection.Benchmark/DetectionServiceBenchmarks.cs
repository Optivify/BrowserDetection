using BenchmarkDotNet.Attributes;
using Microsoft.Extensions.Options;
using Moq;
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

namespace Optivify.BrowserDetection.Benchmark
{
    public class DetectionServiceBenchmarks
    {
        private DetectionDataLoader detectionDataLoader;

        private ClientHintsEngineDetector clientHintsEngineDetector;

        private ClientHintsBrowserDetector clientHintsBrowserDetector;

        private ClientHintsDeviceDetector clientHintsDeviceDetector;

        private IEngineDetector[] engineDetectors;

        private IBrowserDetector[] browserDetectors;

        private IPlatformDetector[] platformDetectors;

        private IDeviceTypeDetector[] deviceDetectors;

        private IDeviceOperatingSystemDetector[] operatingSystemDetectors;

        private IDeviceArchitectureDetector[] architectureDetectors;

        private IDetectionService detectionServiceChromeOnWindows10;

        private IDetectionService detectionServiceSafariOniOS;

        public const string ClientHintsUserAgentChromeOnWindows11 = "\"Chromium\";v=\"106\", \"Google Chrome\";v=\"106\", \"Not;A=Brand\";v=\"99\"";

        public const string ClientHintsUserAgentSafariOniOS = "";

        public const string UserAgentChromeOnWindows10 = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/70.0.3538.77 Safari/537.36";

        public const string UserAgentSafariOniOS = "Mozilla/5.0 (iPhone; CPU iPhone OS 15_5 like Mac OS X) AppleWebKit/605.1.15 (KHTML, like Gecko) Version/15.4 Mobile/15E148 Safari/604.1";

        public DetectionServiceBenchmarks()
        {
            this.clientHintsEngineDetector = new ClientHintsEngineDetector();
            this.clientHintsBrowserDetector = new ClientHintsBrowserDetector();
            this.clientHintsDeviceDetector = new ClientHintsDeviceDetector();

            this.detectionDataLoader = new DetectionDataLoader();


            this.engineDetectors = new IEngineDetector[]
            {
                new BlinkEngineDetector(detectionDataLoader),
                new WebKitEngineDetector(detectionDataLoader),
                new GeckoEngineDetector(detectionDataLoader)
            };

            this.browserDetectors = new IBrowserDetector[]
            {
                new EdgeBrowserDetector(detectionDataLoader),
                new ChromeBrowserDetector(detectionDataLoader),
                new SafariBrowserDetector(detectionDataLoader)
            };

            this.platformDetectors = new IPlatformDetector[]
            {
                new AndroidPlatformDetector(detectionDataLoader),
                new iPadPlatformDetector(detectionDataLoader),
                new iPhonePlatformDetector(detectionDataLoader),
                new LinuxPlatformDetector(detectionDataLoader),
                new MacintoshPlatformDetector(detectionDataLoader),
                new WindowsPlatformDetector(detectionDataLoader)
            };

            this.deviceDetectors = new IDeviceTypeDetector[]
            {
                new DesktopDeviceDetector(detectionDataLoader),
                new MobileDeviceDetector(detectionDataLoader),
                new TabletDeviceDetector(detectionDataLoader),
            };

            this.operatingSystemDetectors = new IDeviceOperatingSystemDetector[]
            {
                new AndroidDetector(detectionDataLoader),
                new iOSDetector(detectionDataLoader),
                new LinuxDetector(detectionDataLoader),
                new MacintoshDetector(detectionDataLoader),
                new WindowsDetector(detectionDataLoader)
            };

            this.architectureDetectors = new IDeviceArchitectureDetector[]
            {
                new ARMArchitectureDetector(detectionDataLoader),
                new x86_64ArchitectureDetector(detectionDataLoader),
                new x86ArchitectureDetector(detectionDataLoader),
            };

            this.detectionServiceChromeOnWindows10 = this.GetService(ClientHintsUserAgentChromeOnWindows11, UserAgentChromeOnWindows10);
            this.detectionServiceSafariOniOS = this.GetService(ClientHintsUserAgentSafariOniOS, UserAgentSafariOniOS);
        }

        private IClientHintsResolver GetMockClientHintsResolver(string clientHintsUserAgent)
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
                new BrowserDetectionOptions(),

                this.clientHintsEngineDetector,
                this.clientHintsBrowserDetector,
                this.clientHintsDeviceDetector,

                this.GetMockClientHintsResolver(clientHintsUserAgent),
                mockUserAgentResolver.Object,
                this.engineDetectors,
                this.browserDetectors,
                this.platformDetectors,
                this.deviceDetectors,
                this.operatingSystemDetectors,
                this.architectureDetectors);
        }

        [Benchmark]
        public string Detect_ChromeOnWindows10_Browser()
        {
            return this.detectionServiceChromeOnWindows10.Browser.Name;
        }

        [Benchmark]
        public string Detect_ChromeOnWindows10_Platform()
        {
            return this.detectionServiceChromeOnWindows10.Platform.Name;
        }

        [Benchmark]
        public string Detect_SafariOniOS_Browser()
        {
            return this.detectionServiceSafariOniOS.Browser.Name;
        }

        [Benchmark]
        public string Detect_SafariOniOS_Platform()
        {
            return this.detectionServiceSafariOniOS.Platform.Name;
        }
    }
}
