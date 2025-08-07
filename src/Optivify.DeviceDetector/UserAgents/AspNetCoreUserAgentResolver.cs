using Microsoft.AspNetCore.Http;

namespace Optivify.DeviceDetector.UserAgents;

public class AspNetCoreUserAgentResolver : BaseUserAgentResolver
{
    public AspNetCoreUserAgentResolver(IHttpContextAccessor httpContextAccessor)
    {
        UserAgent = httpContextAccessor.HttpContext?.Request.Headers[UserAgentHeaderName].FirstOrDefault();
    }
}
