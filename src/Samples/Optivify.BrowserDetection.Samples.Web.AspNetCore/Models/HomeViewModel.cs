namespace Optivify.BrowserDetection.Samples.Web.AspNetCore.Models;

public class HomeViewModel
{
    public bool SkipClientHintsDetection { get; set; }

    public string UserAgent { get; set; } = string.Empty;
}