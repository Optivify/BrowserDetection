namespace Optivify.BrowserDetection.DeviceArchitectures;

public class DeviceArchitecture : IDeviceArchitecture
{
    public string Name { get; }

    public DeviceArchitecture(string name)
    {
        this.Name = name;
    }
}
