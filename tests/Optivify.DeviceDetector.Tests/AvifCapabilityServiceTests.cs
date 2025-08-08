using Optivify.DeviceDetector.Browsers;
using Optivify.DeviceDetector.Capabilities.Avif;

namespace Optivify.DeviceDetector.Tests;

[TestClass]
public class AvifCapabilityServiceTests
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
        "",
        "Mozilla/5.0 (Macintosh; Intel Mac OS X 10_15_3) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/99.0.4844.84 Safari/537.36",
        true
    )]

    // Chrome on iPhone
    [DataRow(
        "105.0.5195.147",
        "",
        "Mozilla/5.0 (iPhone; CPU iPhone OS 16_0 like Mac OS X) AppleWebKit/605.1.15 (KHTML, like Gecko) CriOS/105.0.5195.147 Mobile/15E148 Safari/604.1",
        true
    )]

    // Chrome on iPad
    [DataRow(
        "105.0.5195.147",
        "",
        "Mozilla/5.0 (iPad; CPU OS 16_0 like Mac OS X) AppleWebKit/605.1.15 (KHTML, like Gecko) CriOS/105.0.5195.147 Mobile/15E148 Safari/604.1",
        true
    )]

    // Chrome on Samsung Tablet S7+
    [DataRow(
        "88.0.4324.152",
        "",
        "Mozilla/5.0 (Linux; Android 11; SM-T970) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/88.0.4324.152 Safari/537.36",
        true
    )]

    // Chrome on Samsung S22
    [DataRow(
        "80.0.3987.119",
        "",
        "Mozilla/5.0 (Linux; Android 12; SM-S906N Build/QP1A.190711.020; wv) AppleWebKit/537.36 (KHTML, like Gecko) Version/4.0 Chrome/80.0.3987.119 Mobile Safari/537.36",
        false
    )]

    // Chrome on Samsung Tablet A10.1
    [DataRow(
        "28.0.1500.94",
        "",
        "Mozilla/5.0 (Linux; Android 4.4.2; en-us; SAMSUNG SM-T530 Build/KOT49H) AppleWebKit/537.36 (KHTML, like Gecko) Version/1.5 Chrome/28.0.1500.94 Safari/537.36",
        false
    )]

    // Chrome on Linux
    [DataRow(
        "55.0.2919.83",
        "",
        "Mozilla/5.0 (X11; Ubuntu; Linux x86_64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/55.0.2919.83 Safari/537.36",
        false
    )]

    // Chrome on Windows 10
    [DataRow(
        "70.0.3538.77",
        "",
        "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/70.0.3538.77 Safari/537.36",
        false
    )]

    // Chrome on Windows 7
    [DataRow(
        "41.0.2228.0",
        "",
        "Mozilla/5.0 (Windows NT 6.1) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/41.0.2228.0 Safari/537.36",
        false
    )]
    public void Chrome(
        string version,
        string clientHintsUserAgent,
        string userAgent,
        bool isSupported)
    {
        var service = MockServices.GetMockedCapabilityService(clientHintsUserAgent, userAgent);

        Assert.AreEqual(isSupported, service.HasCapability<AvifCapability>());
    }

    #endregion

    #region Safari

    [TestMethod]
    // Safari on macOS
    [DataRow(
        "15.4",
        "",
        "Mozilla/5.0 (Macintosh; Intel Mac OS X 12_4) AppleWebKit/605.1.15 (KHTML, like Gecko) Version/15.4 Safari/605.1.15",
        false
    )]
    // Safari on macOS
    [DataRow(
        "14.0.3",
        "",
        "Mozilla/5.0 (Macintosh; Intel Mac OS X 10_15_6) AppleWebKit/605.1.15 (KHTML, like Gecko) Version/14.0.3 Safari/605.1.15",
        false
    )]
    // Safari on iPhone
    [DataRow(
        "15.4",
        "",
        "Mozilla/5.0 (iPhone; CPU iPhone OS 15_5 like Mac OS X) AppleWebKit/605.1.15 (KHTML, like Gecko) Version/15.4 Mobile/15E148 Safari/604.1",
        false
    )]
    // Safari on iPhone
    [DataRow(
        "12.1",
        "",
        "Mozilla/5.0 (iPhone; CPU iPhone OS 12_2 like Mac OS X) AppleWebKit/605.1.15 (KHTML, like Gecko) Version/12.1 Mobile/15E148 Safari/604.1",
        false
    )]
    // Safari on Ipad
    [DataRow(
        "15.4",
        "",
        "Mozilla/5.0 (iPad; CPU OS 15_5 like Mac OS X) AppleWebKit/605.1.15 (KHTML, like Gecko) Version/15.4 Mobile/15E148 Safari/604.1",
        false
    )]
    // Safari on iPhone
    [DataRow(
        "18.4",
        "",
        "Mozilla/5.0 (iPhone; CPU iPhone OS 18_6 like Mac OS X) AppleWebKit/605.1.15 (KHTML, like Gecko) Version/18.4 Mobile/15E148 Safari/604.1",
        true
    )]
    public void Safari(
        string version,
        string clientHintsUserAgent,
        string userAgent,
        bool isSupported)
    {
        var service = MockServices.GetMockedCapabilityService(clientHintsUserAgent, userAgent);

        Assert.AreEqual(isSupported, service.HasCapability<AvifCapability>());
    }

    #endregion

    #region Edge

    [TestMethod]
    // Edge on Windows 10
    [DataRow(
        "102.0.1245.44",
        "",
        "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/103.0.0.0 Safari/537.36 Edg/102.0.1245.44",
        false
    )]
    // Edge on Windows 10
    [DataRow(
        "138.0.3351.121",
        "",
        "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/139.0.0.0 Safari/537.36 Edg/138.0.3351.121",
        true
    )]
    // Edge on Mac OS X
    [DataRow(
        "102.0.1245.44",
        "",
        "Mozilla/5.0 (Macintosh; Intel Mac OS X 12_4) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/103.0.0.0 Safari/537.36 Edg/102.0.1245.44",
        false
    )]
    // Edge on Samsung S10
    [DataRow(
        "100.0.1185.50",
        "",
        "Mozilla/5.0 (Linux; Android 10; SM-G973F) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/103.0.5060.53 Mobile Safari/537.36 EdgA/100.0.1185.50",
        false
    )]
    // Edge on iPhone
    [DataRow(
        "100.1185.50",
        "",
        "Mozilla/5.0 (iPhone; CPU iPhone OS 15_5 like Mac OS X) AppleWebKit/605.1.15 (KHTML, like Gecko) Version/15.0 EdgiOS/100.1185.50 Mobile/15E148 Safari/605.1.15",
        false
    )]
    public void Edge(
        string version,
        string clientHintsUserAgent,
        string userAgent,
        bool isSupported)
    {
        var service = MockServices.GetMockedCapabilityService(clientHintsUserAgent, userAgent);

        Assert.AreEqual(isSupported, service.HasCapability<AvifCapability>());
    }

    #endregion

    #region Samsung Internet

    [TestMethod]
    // SamsungBrowser on Android
    [DataRow(
        "18.0",
        "",
        "Mozilla/5.0 (Linux; Android 12; SAMSUNG SM-G991U) AppleWebKit/537.36 (KHTML, like Gecko) SamsungBrowser/18.0 Chrome/99.0.4844.88 Mobile Safari/537.36",
        true
    )]
    public void SamsungBrowser(
        string version,
        string clientHintsUserAgent,
        string userAgent,
        bool isSupported)
    {
        var service = MockServices.GetMockedCapabilityService(clientHintsUserAgent, userAgent);

        Assert.AreEqual(isSupported, service.HasCapability<AvifCapability>());
    }

    #endregion
}