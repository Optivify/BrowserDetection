using Optivify.BrowserDetection.DeviceTypes;

namespace Optivify.BrowserDetection.ClientHints.Devices;

public interface IClientHintsDeviceDetector
{
    IDeviceType? GetDevice(string userAgentMobile);
}

public class ClientHintsDeviceDetector : IClientHintsDeviceDetector
{
    public IDeviceType? GetDevice(string userAgentMobile)
    {
        if (string.IsNullOrEmpty(userAgentMobile))
        {
            return null;
        }

        var isMobile = userAgentMobile.Trim('?') == "1";

        return isMobile ? new DeviceType(DeviceTypeNames.Mobile) : null;
    }
}
