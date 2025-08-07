using Microsoft.AspNetCore.Http;
using Optivify.DeviceDetector.ClientHints.Headers;
using Optivify.DeviceDetector.ClientHints.Helpers;
using Optivify.DeviceDetector.Helpers;

namespace Optivify.DeviceDetector.ClientHints;

public interface IClientHintsResolver
{
    string? UserAgent { get; }

    string? UserAgentArch { get; }

    string? UserAgentBitness { get; }

    string? UserAgentFullVersion { get; }

    string? UserAgentFullVersionList { get; }

    string? UserAgentMobile { get; }

    string? UserAgentModel { get; }

    string? UserAgentPlatform { get; }

    Version? UserAgentPlatformVersion { get; }

    double? DevicePixelRatio { get; }

    int? ViewportWidth { get; }

    int? ViewportHeight { get; }
}

public class ClientHintsResolver : IClientHintsResolver
{
    protected IHeaderDictionary? HeaderDictionary;

    protected IDictionary<string, string>? Headers;

    #region User Agent

    private readonly Lazy<string?> _userAgent;

    public string? UserAgent => _userAgent.Value;

    #endregion

    #region User Agent Arch

    private readonly Lazy<string?> _userAgentArch;

    public string? UserAgentArch => _userAgentArch.Value;

    #endregion

    #region User Agent Bitness

    private readonly Lazy<string?> _userAgentBitness;

    public string? UserAgentBitness => _userAgentBitness.Value;

    #endregion

    #region User Agent Full Version

    private readonly Lazy<string?> _userAgentFullVersion;

    public string? UserAgentFullVersion => _userAgentFullVersion.Value;

    #endregion

    #region User Agent Full Version List

    private readonly Lazy<string?> _userAgentFullVersionList;

    public string? UserAgentFullVersionList => _userAgentFullVersionList.Value;

    #endregion

    #region User Agent Mobile

    private readonly Lazy<string?> _userAgentMobile;

    public string? UserAgentMobile => _userAgentMobile.Value;

    #endregion

    #region Device Pixel Ratio

    private readonly Lazy<double?> _devicePixelRatio;

    public double? DevicePixelRatio => _devicePixelRatio.Value;

    #endregion

    #region Model

    private readonly Lazy<string?> _userAgentModel;

    public string? UserAgentModel => _userAgentModel.Value;

    #endregion

    #region Platform

    private readonly Lazy<string?> _userAgentPlatform;

    public string? UserAgentPlatform => _userAgentPlatform.Value;

    #endregion

    #region Platform Version

    private readonly Lazy<Version?> _userAgentPlatformVersion;

    public Version? UserAgentPlatformVersion => _userAgentPlatformVersion.Value;

    #endregion

    #region Viewport Width

    private readonly Lazy<int?> _viewportWidth;

    public int? ViewportWidth => _viewportWidth.Value;

    #endregion

    #region Viewport Height

    private readonly Lazy<int?> _viewportHeight;

    public int? ViewportHeight => _viewportHeight.Value;

    #endregion

    protected ClientHintsResolver()
    {
        _userAgent = new Lazy<string?>(GetUserAgent);
        _userAgentArch = new Lazy<string?>(GetUserAgentArch);
        _userAgentBitness = new Lazy<string?>(GetUserAgentBitness);
        _userAgentFullVersion = new Lazy<string?>(GetUserAgentFullVersion);
        _userAgentFullVersionList = new Lazy<string?>(GetUserAgentFullVersionList);
        _userAgentMobile = new Lazy<string?>(GetUserAgentMobile);
        _devicePixelRatio = new Lazy<double?>(GetDevicePixelRatio);
        _userAgentModel = new Lazy<string?>(GetModel);
        _userAgentPlatform = new Lazy<string?>(GetPlatform);
        _userAgentPlatformVersion = new Lazy<Version?>(GetPlatformVersion);
        _viewportWidth = new Lazy<int?>(GetViewportWidth);
        _viewportHeight = new Lazy<int?>(GetViewportHeight);
    }

    public ClientHintsResolver(IDictionary<string, string> headers) : this()
    {
        Headers = headers;
    }

    public ClientHintsResolver(IHeaderDictionary? headerDictionary) : this()
    {
        HeaderDictionary = headerDictionary;
    }

    private string? GetUserAgent()
    {
        if (HeaderDictionary is not null)
        {
            return HeaderDictionary[RequestHeaderNames.UserAgent].FirstOrDefault();
        }

        if (Headers is not null && Headers.TryGetValue(RequestHeaderNames.UserAgent, out var value))
        {
            return value;
        }

        return null;
    }

    private string? GetUserAgentArch()
    {
        if (HeaderDictionary is not null)
        {
            return HeaderDictionary[RequestHeaderNames.UserAgentArch].FirstOrDefault();
        }

        if (Headers is not null && Headers.TryGetValue(RequestHeaderNames.UserAgentArch, out var value))
        {
            return value;
        }

        return null;
    }

    private string? GetUserAgentBitness()
    {
        if (HeaderDictionary is not null)
        {
            return HeaderDictionary[RequestHeaderNames.UserAgentBitness].FirstOrDefault();
        }

        if (Headers is not null && Headers.TryGetValue(RequestHeaderNames.UserAgentBitness, out var value))
        {
            return value;
        }

        return null;
    }

    private string? GetUserAgentFullVersion()
    {
        if (HeaderDictionary is not null)
        {
            return HeaderDictionary[RequestHeaderNames.UserAgentFullVersion].FirstOrDefault();
        }

        if (Headers is not null && Headers.TryGetValue(RequestHeaderNames.UserAgentFullVersion, out var value))
        {
            return value;
        }

        return null;
    }

    private string? GetUserAgentFullVersionList()
    {
        if (HeaderDictionary is not null)
        {
            return HeaderDictionary[RequestHeaderNames.UserAgentFullVersionList].FirstOrDefault();
        }

        if (Headers is not null && Headers.TryGetValue(RequestHeaderNames.UserAgentFullVersionList, out var value))
        {
            return value;
        }

        return null;
    }

    private string? GetUserAgentMobile()
    {
        if (HeaderDictionary is not null)
        {
            return HeaderDictionary[RequestHeaderNames.UserAgentMobile].FirstOrDefault();
        }

        if (Headers is not null && Headers.TryGetValue(RequestHeaderNames.UserAgentMobile, out var value))
        {
            return value;
        }

        return null;
    }

    private double? GetDevicePixelRatio()
    {
        if (HeaderDictionary is not null &&
            double.TryParse(HeaderDictionary[RequestHeaderNames.DevicePixelRatio].FirstOrDefault(), out var headerDictionaryValue))
        {
            return headerDictionaryValue;
        }

        if (Headers is not null &&
            Headers.TryGetValue(RequestHeaderNames.DevicePixelRatio, out _) &&
            double.TryParse(Headers[RequestHeaderNames.DevicePixelRatio], out var headersValue))
        {
            return headersValue;
        }

        return null;
    }

    private string? GetModel()
    {
        if (HeaderDictionary is not null)
        {
            return HeaderDictionary[RequestHeaderNames.UserAgentModel].FirstOrDefault();
        }

        if (Headers is not null && Headers.TryGetValue(RequestHeaderNames.UserAgentModel, out var headersValue))
        {
            return ClientHintsHelpers.GetClientHintsValueFromString(headersValue);
        }

        return null;
    }

    private string? GetPlatform()
    {
        if (HeaderDictionary is not null)
        {
            return HeaderDictionary[RequestHeaderNames.UserAgentPlatform].FirstOrDefault();
        }

        if (Headers is not null && Headers.TryGetValue(RequestHeaderNames.UserAgentPlatform, out var headersValue))
        {
            return ClientHintsHelpers.GetClientHintsValueFromString(headersValue);
        }

        return null;
    }

    private Version? GetPlatformVersion()
    {
        if (HeaderDictionary is not null &&
            VersionHelpers.TryParseSafe(ClientHintsHelpers.GetClientHintsValueFromString(
                HeaderDictionary[RequestHeaderNames.PlatformVersion].FirstOrDefault()), out var headerDictionaryVersion))
        {
            return headerDictionaryVersion;
        }

        if (Headers != null &&
            Headers.TryGetValue(RequestHeaderNames.PlatformVersion, out var value) &&
            VersionHelpers.TryParseSafe(ClientHintsHelpers.GetClientHintsValueFromString(value), out var headersVersion))
        {
            return headersVersion;
        }

        return null;
    }

    private int? GetViewportWidth() => GetIntValue(RequestHeaderNames.ViewportWidth);

    private int? GetViewportHeight() => GetIntValue(RequestHeaderNames.ViewportHeight);

    private int? GetIntValue(string name)
    {
        if (HeaderDictionary is not null && int.TryParse(HeaderDictionary[name].FirstOrDefault(), out var headerDictionaryValue))
        {
            return headerDictionaryValue;
        }

        if (Headers is not null && Headers.TryGetValue(name, out var value) && int.TryParse(value, out var headersValue))
        {
            return headersValue;
        }

        return null;
    }
}
