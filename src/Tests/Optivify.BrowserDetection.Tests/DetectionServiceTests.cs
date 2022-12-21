using Optivify.BrowserDetection.Browsers;
using Optivify.BrowserDetection.DeviceOperatingSystems;
using Optivify.BrowserDetection.DeviceTypes;
using Optivify.BrowserDetection.Engines;
using Optivify.BrowserDetection.Platforms;

namespace Optivify.BrowserDetection.Tests
{
    [TestClass]
    public class DetectionServiceTests
    {
        [TestMethod]
        public void Others()
        {
            var clientHintsUserAgent = Guid.NewGuid().ToString();
            var userAgent = Guid.NewGuid().ToString();
            var service = MockServices.GetMockedDetectionService(clientHintsUserAgent, userAgent);
            var browser = new Browser(BrowserNames.Others, new Version());

            Assert.IsNotNull(service);
            Assert.AreEqual(browser.Name, service.Browser.Name);
            Assert.AreEqual(new Version(), service.Browser.Version);
        }

        #region Chrome

        [TestMethod]
        // Chrome on macOS
        [DataRow(
            "99.0.4844.84",
            PlatformNames.Macintosh,
            DeviceTypeNames.Desktop,
            DeviceOperatingSystemNames.Macintosh,
            "10.15.3",
            "",
            "Mozilla/5.0 (Macintosh; Intel Mac OS X 10_15_3) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/99.0.4844.84 Safari/537.36")]

        //Chrome on iPhone
        [DataRow(
            "105.0.5195.147",
            PlatformNames.iPhone,
            DeviceTypeNames.Mobile,
            DeviceOperatingSystemNames.iOS,
            "16.0",
            "",
            "Mozilla/5.0 (iPhone; CPU iPhone OS 16_0 like Mac OS X) AppleWebKit/605.1.15 (KHTML, like Gecko) CriOS/105.0.5195.147 Mobile/15E148 Safari/604.1")]

        //Chrome on iPad
        [DataRow(
            "105.0.5195.147",
            PlatformNames.iPad,
            DeviceTypeNames.Tablet,
            DeviceOperatingSystemNames.iOS,
            "16.0",
            "",
            "Mozilla/5.0 (iPad; CPU OS 16_0 like Mac OS X) AppleWebKit/605.1.15 (KHTML, like Gecko) CriOS/105.0.5195.147 Mobile/15E148 Safari/604.1")]

        // Chrome on Samsung S22
        [DataRow(
            "80.0.3987.119",
            PlatformNames.Android,
            DeviceTypeNames.Mobile,
            DeviceOperatingSystemNames.Android,
            "12.0",
            "",
            "Mozilla/5.0 (Linux; Android 12; SM-S906N Build/QP1A.190711.020; wv) AppleWebKit/537.36 (KHTML, like Gecko) Version/4.0 Chrome/80.0.3987.119 Mobile Safari/537.36")]

        // Chrome on Samsung Tablet S7+
        [DataRow(
            "88.0.4324.152",
            PlatformNames.Android,
            DeviceTypeNames.Tablet,
            DeviceOperatingSystemNames.Android,
            "11.0",
            "",
            "Mozilla/5.0 (Linux; Android 11; SM-T970) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/88.0.4324.152 Safari/537.36")]

        // Chrome on Samsung Tablet A10.1
        [DataRow(
            "28.0.1500.94",
            PlatformNames.Android,
            DeviceTypeNames.Tablet,
            DeviceOperatingSystemNames.Android,
            "4.4.2",
            "",
            "Mozilla/5.0 (Linux; Android 4.4.2; en-us; SAMSUNG SM-T530 Build/KOT49H) AppleWebKit/537.36 (KHTML, like Gecko) Version/1.5 Chrome/28.0.1500.94 Safari/537.36")]

        // Chrome on Linux
        [DataRow(
            "55.0.2919.83",
            PlatformNames.Linux,
            DeviceTypeNames.Desktop,
            DeviceOperatingSystemNames.Linux,
            "0.0",
            "",
            "Mozilla/5.0 (X11; Ubuntu; Linux x86_64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/55.0.2919.83 Safari/537.36")]

        // Chrome on Windows 10
        [DataRow(
            "70.0.3538.77",
            PlatformNames.Windows,
            DeviceTypeNames.Desktop,
            DeviceOperatingSystemNames.Windows,
            "10.0",
            "",
            "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/70.0.3538.77 Safari/537.36")]

        // Chrome on Windows 7
        [DataRow(
            "41.0.2228.0",
            PlatformNames.Windows,
            DeviceTypeNames.Desktop,
            DeviceOperatingSystemNames.Windows,
            "6.1",
            "",
            "Mozilla/5.0 (Windows NT 6.1) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/41.0.2228.0 Safari/537.36")]
        public void Chrome(
            string version,
            string platform,
            string device,
            string os,
            string osVersion,
            string clientHintsUserAgent,
            string userAgent)
        {
            var service = MockServices.GetMockedDetectionService(clientHintsUserAgent, userAgent);
            var browserVersion = new Version(version);

            Assert.IsNotNull(service);

            Assert.AreEqual(BrowserNames.Chrome, service.Browser.Name);
            Assert.AreEqual(browserVersion, service.Browser.Version);
            Assert.AreEqual(platform, service.Platform.Name);
            Assert.AreEqual(device, service.Device.Type);
            Assert.AreEqual(os, service.OperatingSystem.Name);
            Assert.AreEqual(osVersion, service.OperatingSystem.Version.ToString());
        }

        #endregion

        #region Safari

        [TestMethod]
        // Safari on macOS
        [DataRow(
            "605.1.15",
            "15.4",
            PlatformNames.Macintosh,
            DeviceTypeNames.Desktop,
            DeviceOperatingSystemNames.Macintosh,
            "12.4",
            "",
            "Mozilla/5.0 (Macintosh; Intel Mac OS X 12_4) AppleWebKit/605.1.15 (KHTML, like Gecko) Version/15.4 Safari/605.1.15")]
        // Safari on macOS
        [DataRow(
            "605.1.15",
            "14.0.3",
            PlatformNames.Macintosh,
            DeviceTypeNames.Desktop,
            DeviceOperatingSystemNames.Macintosh,
            "10.15.6",
            "",
            "Mozilla/5.0 (Macintosh; Intel Mac OS X 10_15_6) AppleWebKit/605.1.15 (KHTML, like Gecko) Version/14.0.3 Safari/605.1.15")]
        // Safari on iPhone
        [DataRow(
            "605.1.15",
            "15.4",
            PlatformNames.iPhone,
            DeviceTypeNames.Mobile,
            DeviceOperatingSystemNames.iOS,
            "15.5",
            "",
            "Mozilla/5.0 (iPhone; CPU iPhone OS 15_5 like Mac OS X) AppleWebKit/605.1.15 (KHTML, like Gecko) Version/15.4 Mobile/15E148 Safari/604.1")]
        // Safari on iPhone
        [DataRow(
            "605.1.15",
            "12.1",
            PlatformNames.iPhone,
            DeviceTypeNames.Mobile,
            DeviceOperatingSystemNames.iOS,
            "12.2",
            "",
            "Mozilla/5.0 (iPhone; CPU iPhone OS 12_2 like Mac OS X) AppleWebKit/605.1.15 (KHTML, like Gecko) Version/12.1 Mobile/15E148 Safari/604.1")]
        // Safari on Ipad
        [DataRow(
            "605.1.15",
            "15.4",
            PlatformNames.iPad,
            DeviceTypeNames.Tablet,
            DeviceOperatingSystemNames.iOS,
            "15.5",
            "",
            "Mozilla/5.0 (iPad; CPU OS 15_5 like Mac OS X) AppleWebKit/605.1.15 (KHTML, like Gecko) Version/15.4 Mobile/15E148 Safari/604.1")]
        public void Safari(
            string engineVersion,
            string version,
            string platform,
            string device,
            string os,
            string osVersion,
            string clientHintsUserAgent,
            string userAgent)
        {
            var service = MockServices.GetMockedDetectionService(clientHintsUserAgent, userAgent);

            Assert.IsNotNull(service);
            Assert.AreEqual(EngineNames.WebKit, service.Engine.Name);
            Assert.AreEqual(new Version(engineVersion), service.Engine.Version);
            Assert.AreEqual(BrowserNames.Safari, service.Browser.Name);
            Assert.AreEqual(new Version(version), service.Browser.Version);
            Assert.AreEqual(platform, service.Platform.Name);
            Assert.AreEqual(device, service.Device.Type);
            Assert.AreEqual(os, service.OperatingSystem.Name);
            Assert.AreEqual(osVersion, service.OperatingSystem.Version.ToString());
        }

        #endregion

        #region Edge

        [TestMethod]
        // Edge on Windows 10
        [DataRow(
            "102.0.1245.44",
            PlatformNames.Windows,
            DeviceTypeNames.Desktop,
            DeviceOperatingSystemNames.Windows,
            "10.0",
            "",
            "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/103.0.0.0 Safari/537.36 Edg/102.0.1245.44")]
        // Edge on Mac OS X
        [DataRow(
            "102.0.1245.44",
            PlatformNames.Macintosh,
            DeviceTypeNames.Desktop,
            DeviceOperatingSystemNames.Macintosh,
            "12.4",
            "",
            "Mozilla/5.0 (Macintosh; Intel Mac OS X 12_4) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/103.0.0.0 Safari/537.36 Edg/102.0.1245.44")]
        // Edge on Samsung S10
        [DataRow(
            "100.0.1185.50",
            PlatformNames.Android,
            DeviceTypeNames.Mobile,
            DeviceOperatingSystemNames.Android,
            "10.0",
            "",
            "Mozilla/5.0 (Linux; Android 10; SM-G973F) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/103.0.5060.53 Mobile Safari/537.36 EdgA/100.0.1185.50")]
        // Edge on iPhone
        [DataRow(
            "100.1185.50",
            PlatformNames.iPhone,
            DeviceTypeNames.Mobile,
            DeviceOperatingSystemNames.iOS,
            "15.5",
            "",
            "Mozilla/5.0 (iPhone; CPU iPhone OS 15_5 like Mac OS X) AppleWebKit/605.1.15 (KHTML, like Gecko) Version/15.0 EdgiOS/100.1185.50 Mobile/15E148 Safari/605.1.15")]
        public void Edge(
            string version,
            string platform,
            string device,
            string os,
            string osVersion,
            string clientHintsUserAgent,
            string userAgent)
        {
            var service = MockServices.GetMockedDetectionService(clientHintsUserAgent, userAgent);
            var browserVersion = new Version(version);

            Assert.IsNotNull(service);
            Assert.AreEqual(BrowserNames.Edge, service.Browser.Name);
            Assert.AreEqual(browserVersion, service.Browser.Version);
            Assert.AreEqual(platform, service.Platform.Name);
            Assert.AreEqual(device, service.Device.Type);
            Assert.AreEqual(os, service.OperatingSystem.Name);
            Assert.AreEqual(osVersion, service.OperatingSystem.Version.ToString());
        }

        #endregion
        
        #region Samsung Internet

        [TestMethod]
        // SamsungBrowser on Android
        [DataRow(
            "18.0",
            PlatformNames.Android,
            DeviceTypeNames.Mobile,
            DeviceOperatingSystemNames.Android,
            "12.0",
            "",
            "Mozilla/5.0 (Linux; Android 12; SAMSUNG SM-G991U) AppleWebKit/537.36 (KHTML, like Gecko) SamsungBrowser/18.0 Chrome/99.0.4844.88 Mobile Safari/537.36")]
       
        public void SamsungBrowser(
            string version,
            string platform,
            string device,
            string os,
            string osVersion,
            string clientHintsUserAgent,
            string userAgent)
        {
            var service = MockServices.GetMockedDetectionService(clientHintsUserAgent, userAgent);
            var browserVersion = new Version(version);

            Assert.IsNotNull(service);
            Assert.AreEqual(BrowserNames.SamsungBrowser, service.Browser.Name);
            Assert.AreEqual(browserVersion, service.Browser.Version);
            Assert.AreEqual(platform, service.Platform.Name);
            Assert.AreEqual(device, service.Device.Type);
            Assert.AreEqual(os, service.OperatingSystem.Name);
            Assert.AreEqual(osVersion, service.OperatingSystem.Version.ToString());
        }

        #endregion
    }
}
