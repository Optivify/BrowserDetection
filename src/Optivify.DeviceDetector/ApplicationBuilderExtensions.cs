using Microsoft.AspNetCore.Builder;
using Optivify.DeviceDetector.ClientHints;

namespace Optivify.DeviceDetector;

public static class ApplicationBuilderExtensions
{
    public static IApplicationBuilder UseDeviceDetector(this IApplicationBuilder app)
    {
        return app.UseMiddleware<ClientHintsMiddleware>();
    }
}
