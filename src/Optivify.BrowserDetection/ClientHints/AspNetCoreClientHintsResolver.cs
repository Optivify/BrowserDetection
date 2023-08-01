using Microsoft.AspNetCore.Http;

namespace Optivify.BrowserDetection.ClientHints;

public class AspNetCoreClientHintsResolver : ClientHintsResolver
{
    public AspNetCoreClientHintsResolver(IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor.HttpContext?.Request.Headers)
    {
    }
}
