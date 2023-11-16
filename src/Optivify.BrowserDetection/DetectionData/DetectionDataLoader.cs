using System.Text.Json;

namespace Optivify.BrowserDetection.DetectionData;

public class DetectionDataLoader : IDetectionDataLoader
{
    public Lazy<DetectionDataModel> detectionData = new(GetDetectionDataFromEmbeddedResource);

    public DetectionDataModel GetDetectionData() => this.detectionData.Value;

    private static DetectionDataModel GetDetectionDataFromEmbeddedResource()
    {
        DetectionDataModel? result = null;
        var assembly = typeof(DetectionDataLoader).Assembly;
        using var stream = assembly.GetManifestResourceStream($"{assembly.GetName().Name}.DetectionData.detection-data.json");

        if (stream is null)
        {
            return result ?? new DetectionDataModel();
        }

        using var reader = new StreamReader(stream);
        result = JsonSerializer.Deserialize<DetectionDataModel>(reader.ReadToEnd());

        return result ?? new DetectionDataModel();
    }
}
