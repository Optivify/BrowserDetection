using Microsoft.AspNetCore.Http;

namespace Optivify.BrowserDetection.UserAgents;

public class AspNetCoreUserAgentResolver : BaseUserAgentResolver
{
    public AspNetCoreUserAgentResolver(IHttpContextAccessor httpContextAccessor)
    {
        this.UserAgent = httpContextAccessor.HttpContext?.Request.Headers[UserAgentHeaderName].FirstOrDefault();
    }
}
