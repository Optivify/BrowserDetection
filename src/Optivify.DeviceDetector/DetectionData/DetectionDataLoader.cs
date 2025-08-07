using Optivify.DeviceDetector.Helpers;

namespace Optivify.DeviceDetector.DetectionData;

public class DetectionDataLoader : IDetectionDataLoader
{
    protected Lazy<DetectionDataModel> DetectionData = new(GetDetectionDataFromEmbeddedResource);

    public DetectionDataModel GetCapabilityData() => DetectionData.Value;

    private static DetectionDataModel GetDetectionDataFromEmbeddedResource()
    {
        return ResourceLoader.LoadFromEmbeddedResource<DetectionDataModel>($"{typeof(DetectionDataLoader).Namespace}.detection-data.json")
               ?? new DetectionDataModel();
    }
}
