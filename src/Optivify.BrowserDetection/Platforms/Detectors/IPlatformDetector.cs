namespace Optivify.BrowserDetection.Platforms.Detectors
{
    public interface IPlatformDetector
    {
        int Order { get; }

        string PlatformName { get; }

        bool TryParse(string userAgent, out IPlatform platform);
    }
}
