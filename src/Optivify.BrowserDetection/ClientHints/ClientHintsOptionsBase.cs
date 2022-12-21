using Optivify.BrowserDetection.ClientHints.Headers;
using System.Text;

namespace Optivify.BrowserDetection.ClientHints
{
    public abstract class AcceptClientHintsOptionsBase
    {
        public bool AcceptUserAgentArch { get; set; }

        public bool AcceptUserAgentBitness { get; set; }

        public bool AcceptUserAgentFullVersion { get; set; }

        public bool AcceptUserAgentFullVersionList { get; set; }

        public bool AcceptDevicePixelRatio { get; set; }

        public bool AcceptUserAgentModel { get; set; }

        public bool AcceptPlatformVersion { get; set; }

        public bool AcceptViewportWidth { get; set; }

        public bool AcceptWidth { get; set; }

        public override string ToString()
        {
            var sb = new StringBuilder();

            if (this.AcceptUserAgentArch)
            {
                sb.Append(AcceptClientHintsHeaderValues.UserAgentArch).Append(", ");
            }
            
            if (this.AcceptUserAgentBitness)
            {
                sb.Append(AcceptClientHintsHeaderValues.UserAgentBitness).Append(", ");
            }

            if (this.AcceptUserAgentFullVersion)
            {
                sb.Append(AcceptClientHintsHeaderValues.UserAgentFullVersion).Append(", ");
            }

            if (this.AcceptUserAgentFullVersionList)
            {
                sb.Append(AcceptClientHintsHeaderValues.UserAgentFullVersionList).Append(", ");
            }

            if (this.AcceptUserAgentModel)
            {
                sb.Append(AcceptClientHintsHeaderValues.UserAgentModel).Append(", ");
            }

            if (this.AcceptDevicePixelRatio)
            {
                sb.Append(AcceptClientHintsHeaderValues.DevicePixelRatio).Append(", ");
            }

            if (this.AcceptPlatformVersion)
            {
                sb.Append(AcceptClientHintsHeaderValues.PlatformVersion).Append(", ");
            }

            if (this.AcceptViewportWidth)
            {
                sb.Append(AcceptClientHintsHeaderValues.ViewportWidth).Append(", ");
            }

            if (this.AcceptWidth)
            {
                sb.Append(AcceptClientHintsHeaderValues.Width).Append(", ");
            }

            if (sb.Length > 0)
            {
                sb.Length -= 2;
            }

            return sb.ToString();
        }
    }
}
