using Moq;
using Optivify.BrowserDetection.Browsers.Detectors;
using Optivify.BrowserDetection.ClientHints;
using Optivify.BrowserDetection.ClientHints.Browsers;
using Optivify.BrowserDetection.ClientHints.Devices;
using Optivify.BrowserDetection.ClientHints.Engines;
using Optivify.BrowserDetection.DeviceArchitectures.Detectors;
using Optivify.BrowserDetection.DeviceOperatingSystems.Detectors;
using Optivify.BrowserDetection.DeviceTypes.Detectors;
using Optivify.BrowserDetection.Engines.Detectors;
using Optivify.BrowserDetection.Platforms.Detectors;
using Optivify.BrowserDetection.Services;
using Optivify.BrowserDetection.UserAgents;

namespace Optivify.BrowserDetection.Tests
{
    internal static class MockServices
    {
        #region Client Hints User Agent Resolver

        internal static IClientHintsResolver GetMockedClientHintsUserAgentResolver(string clientHintsUserAgent)
        {
            return MockClientHintsUserAgentResolver(clientHintsUserAgent).Object;
        }

        internal static Mock<IClientHintsResolver> MockClientHintsUserAgentResolver(string userAclientHintsUserAgentgent)
        {
            var resolver = new Mock<IClientHintsResolver>();
            resolver.Setup(a => a.UserAgent).Returns(userAclientHintsUserAgentgent);

            return resolver;
        }

        #endregion

        #region User Agent Resolver

        internal static IUserAgentResolver GetMockedUserAgentResolver(string userAgent)
        {
            return MockUserAgentResolver(userAgent).Object;
        }

        internal static Mock<IUserAgentResolver> MockUserAgentResolver(string userAgent)
        {
            var resolver = new Mock<IUserAgentResolver>();
            resolver.Setup(a => a.UserAgent).Returns(userAgent);

            return resolver;
        }

        #endregion

        #region Detection Service

        internal static IDetectionService GetMockedDetectionService(string clientHintsUserAgent, string userAgent)
        {
            return GetMockedDetectionService(GetMockedClientHintsUserAgentResolver(clientHintsUserAgent) , GetMockedUserAgentResolver(userAgent));
        }

        internal static IDetectionService GetMockedDetectionService(IClientHintsResolver clientHintsUserAgentResolver,  IUserAgentResolver userAgentResolver)
        {
            var detectionDataLoader = new DetectionData.DetectionDataLoader();

            var clientHintsEngineDetector = new ClientHintsEngineDetector();
            var clientHintsBrowserDetector = new ClientHintsBrowserDetector();
            var clientHintsDeviceDetector = new ClientHintsDeviceDetector();

            var engineDetectors = new IEngineDetector[]
            {
                new BlinkEngineDetector(detectionDataLoader),
                new WebKitEngineDetector(detectionDataLoader),
                new GeckoEngineDetector(detectionDataLoader)
            };

            var browserDetectors = new IBrowserDetector[]
            {
                new EdgeBrowserDetector(detectionDataLoader),
                new ChromeBrowserDetector(detectionDataLoader),
                new SafariBrowserDetector(detectionDataLoader),
                new SamsungBrowserDetector(detectionDataLoader),
                new FirefoxBrowserDetector(detectionDataLoader),
                new OperaBrowserDetector(detectionDataLoader)
            };

            var platformDetectors = new IPlatformDetector[]
            {
                new AndroidPlatformDetector(detectionDataLoader),
                new iPadPlatformDetector(detectionDataLoader),
                new iPhonePlatformDetector(detectionDataLoader),
                new LinuxPlatformDetector(detectionDataLoader),
                new MacintoshPlatformDetector(detectionDataLoader),
                new WindowsPlatformDetector(detectionDataLoader)
            };

            var deviceTypeDetectors = new IDeviceTypeDetector[]
            {
                new DesktopDeviceDetector(detectionDataLoader),
                new MobileDeviceDetector(detectionDataLoader),
                new TabletDeviceDetector(detectionDataLoader)
            };

            var deviceOperatingSystemDetectors = new IDeviceOperatingSystemDetector[]
            {
                new AndroidDetector(detectionDataLoader),
                new iOSDetector(detectionDataLoader),
                new LinuxDetector(detectionDataLoader),
                new MacintoshDetector(detectionDataLoader),
                new WindowsDetector(detectionDataLoader)
            };

            var deviceArchitectureDetectors = new IDeviceArchitectureDetector[]
            {
                new ARMArchitectureDetector(detectionDataLoader),
                new x86_64ArchitectureDetector(detectionDataLoader),
                new x86ArchitectureDetector(detectionDataLoader)
            };

            return new DetectionService(
                new BrowserDetectionOptions(),

                clientHintsEngineDetector,
                clientHintsBrowserDetector,
                clientHintsDeviceDetector,

                clientHintsUserAgentResolver,
                userAgentResolver,

                engineDetectors, 
                browserDetectors, 
                platformDetectors, 
                deviceTypeDetectors, 
                deviceOperatingSystemDetectors,
                deviceArchitectureDetectors);
        }

        #endregion
    }
}
