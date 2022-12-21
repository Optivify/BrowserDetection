using System;

namespace Optivify.BrowserDetection.Browsers
{
    public interface IBrowser
    {
        /// <summary>
        /// The browser name.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// The browser version.
        /// </summary>
        Version Version { get; }
    }
}
