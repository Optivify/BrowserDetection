﻿using Microsoft.AspNetCore.Mvc;
using Optivify.BrowserDetection.Samples.Web.AspNetCore.Models;
using Optivify.BrowserDetection.Services;
using System.Diagnostics;

namespace Optivify.BrowserDetection.Samples.Web.AspNetCore.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> logger;

        private readonly BrowserDetectionOptions browserDetectionOptions;

        public HomeController(
            ILogger<HomeController> logger, 
            BrowserDetectionOptions browserDetectionOptions)
        {
            this.logger = logger;
            this.browserDetectionOptions = browserDetectionOptions;
        }

        public IActionResult Index()
        {
            var model = new HomeViewModel
            {
                SkipClientHintsDetection = false,
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
                SkipClientHintsDetection = true,
                AcceptClientHints = this.browserDetectionOptions.AcceptClientHints,
                CriticalClientHints = this.browserDetectionOptions.CriticalClientHints
            };

            detectionService.SetBrowserDetectionOptions(customBrowserDetectionOptions);

            var model = new HomeViewModel
            {
                SkipClientHintsDetection = true,
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