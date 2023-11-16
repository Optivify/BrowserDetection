﻿using System.Diagnostics.CodeAnalysis;
using Optivify.BrowserDetection.Browsers;
using Optivify.BrowserDetection.DeviceOperatingSystems;

namespace Optivify.BrowserDetection.Engines.Detectors;

public interface IEngineDetector
{
    int Order { get; }

    string EngineName { get; }

    bool TryParse(IBrowser browser, IDeviceOperatingSystem operatingSystem, string? userAgent, [NotNullWhen(true)] out IEngine? engine);
}
