using Microsoft.AspNetCore.Http;
using Optivify.BrowserDetection.UserAgents;
using System.Linq;

namespace Optivify.BrowserDetection.AspNetCore.UserAgents
{
    public class AspNetCoreUserAgentResolver : BaseUserAgentResolver
    {
        public AspNetCoreUserAgentResolver(IHttpContextAccessor httpContextAccessor)
        {
            this.UserAgent = httpContextAccessor.HttpContext.Request.Headers[UserAgentHeaderName].FirstOrDefault();
        }
    }
}
