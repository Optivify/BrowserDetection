using System.Diagnostics.CodeAnalysis;
using System.Text.RegularExpressions;

namespace Optivify.DeviceDetector.DeviceArchitectures.Detectors;

public abstract class BaseDeviceArchitectureDetector : IDeviceArchitectureDetector
{
    public abstract int Order { get; }

    public abstract string ArchitectureName { get; }

    protected Regex? Regex;

    protected BaseDeviceArchitectureDetector(IReadOnlyDictionary<string, string>? architectures)
    {
        if (architectures == null || !architectures.TryGetValue(ArchitectureName, out var regexString) || string.IsNullOrEmpty(regexString))
        {
            return;
        }

        Regex = new Regex(regexString, RegexOptions.Compiled);
    }

    public virtual bool TryParse(string? userAgent, [NotNullWhen(true)] out IDeviceArchitecture? architecture)
    {
        if (userAgent is not null && Regex is not null && Regex.IsMatch(userAgent))
        {
            architecture = new DeviceArchitecture(ArchitectureName);

            return true;
        }

        architecture = null;

        return false;
    }
}
