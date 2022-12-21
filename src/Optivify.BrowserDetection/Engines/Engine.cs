using System;

namespace Optivify.BrowserDetection.Engines
{
    public class Engine : IEngine
    {
        public string Name { get; }

        public Version Version { get; }

        public Engine(string name, Version version)
        {
            this.Name = name;
            this.Version = version;
        }
    }
}
