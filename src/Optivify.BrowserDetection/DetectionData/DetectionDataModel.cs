using System.Collections.Generic;

namespace Optivify.BrowserDetection.DetectionData
{
    public class DetectionDataModel
    {
        public string Version { get; set; }

        public Dictionary<string, string> Browsers { get; set; }

        public Dictionary<string, string> Engines { get; set; }

        public Dictionary<string, string> Platforms { get; set; }

        public Dictionary<string, Dictionary<string, string>> Devices { get; set; }

        public Dictionary<string, string> OperatingSystems { get; set; }

        public Dictionary<string, string> Architectures { get; set; }
    }
}
