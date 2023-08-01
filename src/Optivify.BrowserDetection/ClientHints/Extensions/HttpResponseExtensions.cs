using Microsoft.AspNetCore.Http;
using Optivify.BrowserDetection.ClientHints.Headers;

namespace Optivify.BrowserDetection.ClientHints.Extensions;

public static class HttpResponseExtensions
{
    public static void SetAcceptClientHintsHeader(this HttpResponse httpResponse, AcceptClientHintsOptions acceptClientHintsOptions)
    {
        var headerValues = acceptClientHintsOptions.ToString();

        if (string.IsNullOrEmpty(headerValues))
        {
            return;
        }

        httpResponse.SetResponseHeader(ResponseHeaderNames.AcceptClientHints, headerValues);
    }

    public static void SetCriticalClientHintsHeader(this HttpResponse httpResponse, CriticalClientHintsOptions criticalClientHintsOptions)
    {
        var headerValues = criticalClientHintsOptions.ToString();

        if (string.IsNullOrEmpty(headerValues))
        {
            return;
        }

        httpResponse.SetResponseHeader(ResponseHeaderNames.CriticalClientHints, headerValues);
    }

    internal static void SetResponseHeader(this HttpResponse httpResponse, string headerName, string headerValue)
    {
        if (string.IsNullOrWhiteSpace(headerValue))
        {
            httpResponse.Headers.Remove(headerName);
        }
        else
        {
            httpResponse.Headers[headerName] = headerValue;
        }
    }
}
