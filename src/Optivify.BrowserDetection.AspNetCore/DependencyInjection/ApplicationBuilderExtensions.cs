using ExtensibleBrowserDetector.AspNetCore.ClientHints;
using Microsoft.AspNetCore.Builder;

namespace Optivify.BrowserDetection.AspNetCore.DependencyInjection
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseClientHintsDetection(this IApplicationBuilder app)
        {
            return app.UseMiddleware<ClientHintsMiddleware>();
        }
    }
}
