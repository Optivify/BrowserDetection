using Microsoft.AspNetCore.Http;
using Optivify.BrowserDetection.ClientHints;

namespace ExtensibleBrowserDetector.AspNetCore.ClientHints
{
    public class AspNetCoreClientHintsResolver : ClientHintsResolver
    {
        public AspNetCoreClientHintsResolver(IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor.HttpContext.Request.Headers)
        {
        }
    }
}
