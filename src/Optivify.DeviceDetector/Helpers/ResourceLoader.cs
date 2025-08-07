using Optivify.DeviceDetector.DetectionData;
using System.Text.Json;

namespace Optivify.DeviceDetector.Helpers;

public static class ResourceLoader
{
    public static TData? LoadFromEmbeddedResource<TData>(string filePath)
    {
        TData? result = default;
        var assembly = typeof(DetectionDataLoader).Assembly;
        using var stream = assembly.GetManifestResourceStream(filePath);

        if (stream is null)
        {
            return result;
        }

        using var reader = new StreamReader(stream);
        try
        {
            result = JsonSerializer.Deserialize<TData>(reader.ReadToEnd());
        }
        catch
        {
            // Wrong format
        }

        return result;
    }
}