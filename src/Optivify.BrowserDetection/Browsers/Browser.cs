using System;

namespace Optivify.BrowserDetection.Browsers
{
    public class Browser : IBrowser
    {
        public string Name { get; }

        public Version Version { get; }

        public Browser(string name, Version version)
        {
            Name = name;
            Version = version;
        }

        public override string ToString()
        {
            return $"{Name}-{Version}";
        }
    }
}
