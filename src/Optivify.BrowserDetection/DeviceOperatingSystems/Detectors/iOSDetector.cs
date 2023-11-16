﻿using System.Diagnostics.CodeAnalysis;
using Optivify.BrowserDetection.DetectionData;
using Optivify.BrowserDetection.Platforms;

namespace Optivify.BrowserDetection.DeviceOperatingSystems.Detectors;

public class iOSDetector : BaseDeviceOperatingSystemDetector
{
    public override int Order => DeviceOperatingSystemDetectorOrders.iOS;

    public override string OperatingSystemName => DeviceOperatingSystemNames.iOS;

    public iOSDetector(IDetectionDataLoader detectionDataLoader) : base(detectionDataLoader.GetDetectionData().OperatingSystems)
    {
    }

    public override bool TryParse(IPlatform platform, string? userAgent, [NotNullWhen(true)] out IDeviceOperatingSystem? operatingSystem)
    {
        platform = new Platform(platform.PlatformString.Replace('_', '.'), platform.Name);

        return base.TryParse(platform, userAgent, out operatingSystem);
    }
}
