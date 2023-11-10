using Microsoft.AspNetCore.Mvc;
using Optivify.BrowserDetection.Samples.Web.AspNetCore.Models;
using Optivify.BrowserDetection.Services;
using System.Diagnostics;
using Microsoft.Extensions.Options;

namespace Optivify.BrowserDetection.Samples.Web.AspNetCore.Controllers
{
    public class HomeController : Controller
    {
        private readonly BrowserDetectionOptions browserDetectionOptions;

        public HomeController(IOptions<BrowserDetectionOptions> options)
        {
            this.browserDetectionOptions = options.Value;
        }

        public IActionResult Index()
        {
            var model = new HomeViewModel
            {
                SkipClientHintsDetection = this.browserDetectionOptions.SkipClientHintsDetection,
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
            base.Request.Headers["User-Agent"] = userAgent;
            var detectionService = base.HttpContext.RequestServices.GetRequiredService<IDetectionService>();

            var customBrowserDetectionOptions = new BrowserDetectionOptions
            {
                SkipClientHintsDetection = this.browserDetectionOptions.SkipClientHintsDetection,
                AcceptClientHints = this.browserDetectionOptions.AcceptClientHints,
                CriticalClientHints = this.browserDetectionOptions.CriticalClientHints
            };

            detectionService.SetBrowserDetectionOptions(customBrowserDetectionOptions);

            var model = new HomeViewModel
            {
                SkipClientHintsDetection = this.browserDetectionOptions.SkipClientHintsDetection,
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
}