using System.Text.Json;

namespace Optivify.BrowserDetection.DetectionData;

public class DetectionDataLoader : IDetectionDataLoader
{
    public Lazy<DetectionDataModel> detectionData;

    public DetectionDataLoader()
    {
        this.detectionData = new Lazy<DetectionDataModel>(() => this.GetDetectionDataFromEmbbededResource());
    }

    private DetectionDataModel GetDetectionDataFromEmbbededResource()
    {
        DetectionDataModel? result = null;
        var assembly = typeof(DetectionDataLoader).Assembly;
        using var stream = assembly.GetManifestResourceStream($"{assembly.GetName().Name}.DetectionData.detection-data.json");

        if (stream is not null)
        {
            using var reader = new StreamReader(stream);
            result = JsonSerializer.Deserialize<DetectionDataModel>(reader.ReadToEnd());
        }

        return result ?? new DetectionDataModel();
    }

    public DetectionDataModel GetDetectionData() => this.detectionData.Value;
}
