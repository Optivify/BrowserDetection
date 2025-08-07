using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Optivify.DeviceDetector.Sample.Models;
using Optivify.DeviceDetector.Services;

namespace Optivify.DeviceDetector.Sample.Controllers;

public class HomeController : Controller
{
    private readonly DeviceDetectorOptions _deviceDetectorOptions;

    public HomeController(IOptions<DeviceDetectorOptions> options)
    {
        _deviceDetectorOptions = options.Value;
    }

    public IActionResult Index()
    {
        var model = new HomeViewModel
        {
            SkipClientHintsDetection = _deviceDetectorOptions.SkipClientHintsDetection,
            UserAgent = Request.Headers["User-Agent"]
        };

        return View(model);
    }

    /// <summary>
    /// Detect custom user agent
    /// </summary>
    /// <param name="userAgent"></param>
    /// <returns></returns>
    [HttpPost]
    public IActionResult Index(string userAgent)
    {
        Request.Headers["User-Agent"] = userAgent;
        var detectionService = HttpContext.RequestServices.GetRequiredService<IDetectionService>();

        var options = new DeviceDetectorOptions
        {
            SkipClientHintsDetection = _deviceDetectorOptions.SkipClientHintsDetection,
            AcceptClientHints = _deviceDetectorOptions.AcceptClientHints,
            CriticalClientHints = _deviceDetectorOptions.CriticalClientHints
        };

        detectionService.SetOptions(options);

        var model = new HomeViewModel
        {
            SkipClientHintsDetection = _deviceDetectorOptions.SkipClientHintsDetection,
            UserAgent = userAgent
        };

        return View(model);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}