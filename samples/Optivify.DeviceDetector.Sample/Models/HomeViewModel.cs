namespace Optivify.DeviceDetector.Sample.Models;

public class HomeViewModel
{
    public bool SkipClientHintsDetection { get; set; }

    public string UserAgent { get; set; } = string.Empty;
}