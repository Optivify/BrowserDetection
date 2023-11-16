using Optivify.BrowserDetection.Platforms;

namespace Optivify.BrowserDetection.Tests;

[TestClass]
public class PlatformTests
{
    [TestMethod]
    // Chrome on Windows
    [DataRow(
        PlatformNames.Windows,
        "Windows NT 10.0; Win64; x64",
        "",
        "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/106.0.0.0 Safari/537.36")]
    // Chrome on Mac
    [DataRow(
        PlatformNames.Macintosh,
        "Macintosh; Intel Mac OS X 12_6",
        "",
        "Mozilla/5.0 (Macintosh; Intel Mac OS X 12_6) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/106.0.0.0 Safari/537.36")] 
    // Chrome on Linux
    [DataRow(
        PlatformNames.Linux,
        "X11; Linux x86_64",
        "",
        "Mozilla/5.0 (X11; Linux x86_64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/106.0.0.0 Safari/537.36")]        
    // Chrome on iPhone
    [DataRow(
        PlatformNames.iPhone,
        "iPhone; CPU iPhone OS 16_0 like Mac OS X",
        "",
        "Mozilla/5.0 (iPhone; CPU iPhone OS 16_0 like Mac OS X) AppleWebKit/605.1.15 (KHTML, like Gecko) CriOS/106.0.5249.92 Mobile/15E148 Safari/604.1")]
    // Chrome on Android
    [DataRow(
        PlatformNames.Android,
        "Linux; Android 10; SM-A205U",
        "",
        "Mozilla/5.0 (Linux; Android 10; SM-A205U) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/106.0.5249.126 Mobile Safari/537.36")]
    public void Chrome(
        string platformName,
        string platformString,
        string clientHintsUserAgent,
        string userAgent)
    {
        var service = MockServices.GetMockedDetectionService(clientHintsUserAgent, userAgent);

        Assert.IsNotNull(service);

        Assert.AreEqual(platformName, service.Platform.Name);
        Assert.AreEqual(platformString, service.Platform.PlatformString);
    }

    [TestMethod]
    // Safari on iPhone
    [DataRow(
        PlatformNames.iPhone,
        "iPhone; CPU iPhone OS 16_0_3 like Mac OS X",
        "",
        "Mozilla/5.0 (iPhone; CPU iPhone OS 16_0_3 like Mac OS X) AppleWebKit/605.1.15 (KHTML, like Gecko) Version/15.6 Mobile/15E148 Safari/604.1")]
    // Safari on iPad
    [DataRow(
        PlatformNames.iPad,
        "iPad; CPU OS 16_0_3 like Mac OS X",
        "",
        "Mozilla/5.0 (iPad; CPU OS 16_0_3 like Mac OS X) AppleWebKit/605.1.15 (KHTML, like Gecko) Version/15.6 Mobile/15E148 Safari/604.1")]
    // Safari on Mac
    [DataRow(
        PlatformNames.Macintosh,
        "Macintosh; Intel Mac OS X 12_6",
        "",
        "Mozilla/5.0 (Macintosh; Intel Mac OS X 12_6) AppleWebKit/605.1.15 (KHTML, like Gecko) Version/15.6 Safari/605.1.15")]
    public void Safari(
        string platformName,
        string platformString,
        string clientHintsUserAgent,
        string userAgent)
    {
        var service = MockServices.GetMockedDetectionService(clientHintsUserAgent, userAgent);

        Assert.IsNotNull(service);

        Assert.AreEqual(platformName, service.Platform.Name);
        Assert.AreEqual(platformString, service.Platform.PlatformString);
    }

    [TestMethod]
    // Edge on Windows
    [DataRow(
        PlatformNames.Windows,
        "Windows NT 10.0; Win64; x64",
        "",
        "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/106.0.0.0 Safari/537.36 Edg/106.0.1370.47")]
    // Edge on iPhone
    [DataRow(
        PlatformNames.iPhone,
        "iPhone; CPU iPhone OS 16_0_3 like Mac OS X",
        "",
        "Mozilla/5.0 (iPhone; CPU iPhone OS 16_0_3 like Mac OS X) AppleWebKit/605.1.15 (KHTML, like Gecko) Version/15.0 EdgiOS/100.1185.50 Mobile/15E148 Safari/605.1.15")]
    public void Edge(
        string platformName,
        string platformString,
        string clientHintsUserAgent,
        string userAgent)
    {
        var service = MockServices.GetMockedDetectionService(clientHintsUserAgent, userAgent);

        Assert.IsNotNull(service);

        Assert.AreEqual(platformName, service.Platform.Name);
        Assert.AreEqual(platformString, service.Platform.PlatformString);
    }
}