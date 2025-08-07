using System.Text;
using Optivify.DeviceDetector.ClientHints.Headers;

namespace Optivify.DeviceDetector.ClientHints;

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

    public bool AcceptViewportHeight { get; set; }

    public bool AcceptWidth { get; set; }

    public override string ToString()
    {
        var sb = new StringBuilder();

        if (AcceptUserAgentArch)
        {
            sb.Append(AcceptClientHintsHeaderValues.UserAgentArch).Append(", ");
        }

        if (AcceptUserAgentBitness)
        {
            sb.Append(AcceptClientHintsHeaderValues.UserAgentBitness).Append(", ");
        }

        if (AcceptUserAgentFullVersion)
        {
            sb.Append(AcceptClientHintsHeaderValues.UserAgentFullVersion).Append(", ");
        }

        if (AcceptUserAgentFullVersionList)
        {
            sb.Append(AcceptClientHintsHeaderValues.UserAgentFullVersionList).Append(", ");
        }

        if (AcceptUserAgentModel)
        {
            sb.Append(AcceptClientHintsHeaderValues.UserAgentModel).Append(", ");
        }

        if (AcceptDevicePixelRatio)
        {
            sb.Append(AcceptClientHintsHeaderValues.DevicePixelRatio).Append(", ");
        }

        if (AcceptPlatformVersion)
        {
            sb.Append(AcceptClientHintsHeaderValues.PlatformVersion).Append(", ");
        }

        if (AcceptViewportWidth)
        {
            sb.Append(AcceptClientHintsHeaderValues.ViewportWidth).Append(", ");
        }

        if (AcceptViewportHeight)
        {
            sb.Append(AcceptClientHintsHeaderValues.ViewportHeight).Append(", ");
        }

        if (AcceptWidth)
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
