using Microsoft.AspNetCore.Http;

namespace Optivify.DeviceDetector.ClientHints;

public class AspNetCoreClientHintsResolver(IHttpContextAccessor httpContextAccessor)
    : ClientHintsResolver(httpContextAccessor.HttpContext?.Request.Headers);
