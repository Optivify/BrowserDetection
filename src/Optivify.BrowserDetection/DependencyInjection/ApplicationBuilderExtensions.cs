using Microsoft.AspNetCore.Builder;
using Optivify.BrowserDetection.ClientHints;

namespace Optivify.BrowserDetection.DependencyInjection;

public static class ApplicationBuilderExtensions
{
    public static IApplicationBuilder UseBrowserDetection(this IApplicationBuilder app)
    {
        return app.UseMiddleware<ClientHintsMiddleware>();
    }
}
