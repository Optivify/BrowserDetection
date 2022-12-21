using System;

namespace Optivify.BrowserDetection.DeviceOperatingSystems
{
    public interface IDeviceOperatingSystem
    {
        string Name { get; }

        Version Version { get; }
    }
}
