using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Optivify.BrowserDetection.ClientHints.Extensions;

namespace Optivify.BrowserDetection.ClientHints;

public class ClientHintsMiddleware
{
    private readonly RequestDelegate next;

    private readonly BrowserDetectionOptions detectionOptions;

    public ClientHintsMiddleware(RequestDelegate next, IOptions<BrowserDetectionOptions> detectionOptions)
    {
        this.next = next;
        this.detectionOptions = detectionOptions.Value;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        if (this.detectionOptions.SkipClientHintsDetection || !context.Request.IsHttps)
        {
            await this.next(context);

            return;
        }

        context.Response.SetCriticalClientHintsHeader(this.detectionOptions.CriticalClientHints);
        context.Response.SetAcceptClientHintsHeader(this.detectionOptions.AcceptClientHints);

        await this.next(context);
    }
}
