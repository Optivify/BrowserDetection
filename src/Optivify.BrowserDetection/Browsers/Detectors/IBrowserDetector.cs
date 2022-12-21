namespace Optivify.BrowserDetection.Browsers.Detectors
{
    public interface IBrowserDetector
    {
        int Order { get; }

        string BrowserName { get; }

        bool TryParse(string userAgent, out IBrowser browser);
    }
}
