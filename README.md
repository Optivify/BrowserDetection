# BrowserDetection
The extensible library that uses client hints and user agent to detect browser, device, platform and architecture.

## Usage
#### 1. Install the package.

````
Install-Package Optivify.BrowserDetection.AspNetCore
````

#### 2. Register the browser detection services in Program.
```csharp
var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;
var configuration = builder.Configuration;
// Add browser detection
services.AddBrowserDetection(configuration);
```
#### 3. Use IDetectionService by injecting in controller constructor or in the view file.
**Use the service in controller:**
```csharp
    public class HomeController : Controller
    {
        private readonly IDetectionService detectionService;
        
        public HomeController(IDetectionService detectionService)
        {
            this.detectionService = detectionService;
        }
        
        public IActionResult Index()
        {
            var browserName = this.detectionService.Browser.Name;
            var browserVersion = this.detectionService.Browser.Version;

            return View();
        }
    }
```
**Use the service in view:**
```razor
@using Optivify.BrowserDetection.Services
@inject IDetectionService detectionService
@detectionService.Browser.Name
```


## Sample Project
You can find the sample project in the folder src/Samples/Optivify.BrowserDetection.Samples.Web.AspNetCore.
The online detection: https://detection.optivify.com
