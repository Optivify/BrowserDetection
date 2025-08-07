using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Optivify.DeviceDetector.ClientHints.Extensions;

namespace Optivify.DeviceDetector.ClientHints;

public class ClientHintsMiddleware(RequestDelegate next, IOptions<DeviceDetectorOptions> detectionOptions)
{
    private readonly DeviceDetectorOptions _detectionOptions = detectionOptions.Value;

    public async Task InvokeAsync(HttpContext context)
    {
        if (_detectionOptions.SkipClientHintsDetection || !context.Request.IsHttps)
        {
            await next(context);

            return;
        }

        context.Response.SetCriticalClientHintsHeader(_detectionOptions.CriticalClientHints);
        context.Response.SetAcceptClientHintsHeader(_detectionOptions.AcceptClientHints);

        await next(context);
    }
}
