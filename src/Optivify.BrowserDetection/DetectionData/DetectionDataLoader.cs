using Newtonsoft.Json;
using System;
using System.IO;

namespace Optivify.BrowserDetection.DetectionData
{
    public class DetectionDataLoader : IDetectionDataLoader
    {
        public Lazy<DetectionDataModel> detectionData;

        public DetectionDataLoader()
        {
            detectionData = new Lazy<DetectionDataModel>(() => GetDetectionDataFromEmbbededResource());
        }

        private DetectionDataModel GetDetectionDataFromEmbbededResource()
        {
            DetectionDataModel result = null;
            var assembly = typeof(DetectionDataLoader).Assembly;
            using (var stream = assembly.GetManifestResourceStream($"{assembly.GetName().Name}.DetectionData.detection-data.json"))
            {
                using (var reader = new StreamReader(stream))
                {
                    using (var jsonReader = new JsonTextReader(reader))
                    {
                        var serializer = new JsonSerializer();
                        result = serializer.Deserialize<DetectionDataModel>(jsonReader);
                    }
                }
            }

            return result ?? new DetectionDataModel();
        }

        public DetectionDataModel GetDetectionData() => detectionData.Value;
    }
}
