using System.Text.RegularExpressions;

namespace Optivify.BrowserDetection.DeviceArchitectures.Detectors;

public abstract class BaseDeviceArchitectureDetector : IDeviceArchitectureDetector
{
    public abstract int Order { get; }

    public abstract string ArchitectureName { get; }

    protected Regex? regex;

    protected BaseDeviceArchitectureDetector(Dictionary<string, string>? architectures)
    {
        if (architectures == null || !architectures.TryGetValue(this.ArchitectureName, out var regexString) || string.IsNullOrEmpty(regexString))
        {
            return;
        }

        this.regex = new Regex(regexString, RegexOptions.Compiled);
    }

    public virtual bool TryParse(string? userAgent, out IDeviceArchitecture? architecture)
    {
        if (userAgent is not null && this.regex is not null && this.regex.IsMatch(userAgent))
        {
            architecture = new DeviceArchitecture(this.ArchitectureName);

            return true;
        }

        architecture = null;

        return false;
    }
}
