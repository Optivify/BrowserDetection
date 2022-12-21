namespace Optivify.BrowserDetection.Platforms
{
    public interface IPlatform
    {
        /// <summary>
        /// The platform name.
        /// </summary>
        string Name { get; }

        string PlatformString { get; }
    }
}
