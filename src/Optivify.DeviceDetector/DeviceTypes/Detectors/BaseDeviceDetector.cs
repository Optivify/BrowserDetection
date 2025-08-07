using System.Diagnostics.CodeAnalysis;
using System.Text.RegularExpressions;
using Optivify.DeviceDetector.Platforms;

namespace Optivify.DeviceDetector.DeviceTypes.Detectors;

public abstract class BaseDeviceDetector : IDeviceTypeDetector
{
    public abstract int Order { get; }

    public abstract string DeviceType { get; }

    protected List<Regex>? RegexList;

    protected BaseDeviceDetector(IReadOnlyDictionary<string, Dictionary<string, string>>? devices)
    {
        if (devices == null || !devices.TryGetValue(DeviceType, out var regexStrings))
        {
            return;
        }

        RegexList = new List<Regex>();
            
        foreach (var regexString in regexStrings.Values.Where(regexString => !string.IsNullOrEmpty(regexString)))
        {
            RegexList.Add(new Regex(regexString, RegexOptions.Compiled));
        }
    }

    public virtual bool TryParse(IPlatform platform, string? userAgent, [NotNullWhen(true)] out IDeviceType? device)
    {
        if (userAgent is not null && RegexList is not null)
        {
            if (RegexList.Any(regex => regex.IsMatch(platform.PlatformString)))
            {
                device = new DeviceType(DeviceType);

                return true;
            }
        }

        device = null;

        return false;
    }
}
