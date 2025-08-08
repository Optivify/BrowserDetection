# DeviceDetector
The extensible library that uses client hints and user agent to detect browser, device, platform and architecture.

## Usage
#### 1. Install the package.

````
Install-Package Optivify.DeviceDetector
````

#### 2. Register device detector service and use device detector middleware in Program.cs.
```csharp
var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;

services.AddDeviceDetector();
...

app.UseDeviceDetector();
```
#### 3. Use IDetectionService by injecting in controller constructor or in the view file.
**Use the service in controller:**
```csharp
public class HomeController(IDetectionService detectionService) : Controller
{
    public IActionResult Index()
    {
        var browserName = detectionService.Browser.Name;
        var browserVersion = detectionService.Browser.Version;

        return View();
    }
}
```
**Use the service in view:**
```razor
@using Optivify.DeviceDetector.Services
@inject IDetectionService detectionService
@detectionService.Browser.Name
```


## Sample Project
You can find the sample project in the folder src/Samples/Optivify.DeviceDetector.Samples.Web.AspNetCore.
