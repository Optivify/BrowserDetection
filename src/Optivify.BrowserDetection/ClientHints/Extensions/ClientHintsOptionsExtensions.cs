using Optivify.BrowserDetection.ClientHints.Headers;
using System.Text;

namespace Optivify.BrowserDetection.ClientHints.Extensions
{
    public static class ClientHintsOptionsExtensions
    {
        public static string GetValue(this AcceptClientHintsOptions clientHintsOptions)
        {
            var sb = new StringBuilder();

            if (clientHintsOptions.AcceptDevicePixelRatio)
            {
                sb.Append(AcceptClientHintsHeaderValues.DevicePixelRatio).Append(",");
            }

            if (clientHintsOptions.AcceptViewportWidth)
            {
                sb.Append(AcceptClientHintsHeaderValues.ViewportWidth).Append(",");
            }

            if (sb.Length > 0)
            {
                sb.Length -= 1;
            }

            return sb.ToString();
        }
    }
}
