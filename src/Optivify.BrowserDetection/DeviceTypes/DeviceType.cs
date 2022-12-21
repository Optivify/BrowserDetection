namespace Optivify.BrowserDetection.DeviceTypes
{
    public class DeviceType : IDeviceType
    {
        public string Type { get; }

        public DeviceType(string name)
        {
            this.Type = name;
        }
    }
}
