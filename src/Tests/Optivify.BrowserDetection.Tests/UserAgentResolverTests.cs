using Microsoft.AspNetCore.Http;
using Moq;
using Optivify.BrowserDetection.UserAgents;

namespace Optivify.BrowserDetection.Tests
{
    [TestClass]
    public class UserAgentResolverTests
    {
        [TestMethod]
        public void CreateUserAgentResolver_GiveUserAgent_ReturnCorrectUserAgent()
        {
            var httpContext = new DefaultHttpContext();
            var userAgent = Guid.NewGuid().ToString();
            httpContext.Request.Headers.TryAdd(AspNetCoreUserAgentResolver.UserAgentHeaderName, userAgent);

            var httpContextAccessor = new HttpContextAccessor { HttpContext = httpContext };
            var userAgentResolver = new AspNetCoreUserAgentResolver(httpContextAccessor);

            Assert.AreEqual(userAgentResolver.UserAgent, userAgent);
        }
    }
}