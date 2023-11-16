using Microsoft.AspNetCore.Http;
using Optivify.BrowserDetection.ClientHints.Headers;
using Optivify.BrowserDetection.ClientHints.Helpers;
using Optivify.BrowserDetection.Helpers;

namespace Optivify.BrowserDetection.ClientHints;

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
    protected IHeaderDictionary? headerDictionary;

    protected IDictionary<string, string>? headers;

    #region User Agent

    private readonly Lazy<string?> userAgent;

    public string? UserAgent => this.userAgent.Value;

    #endregion

    #region User Agent Arch

    private readonly Lazy<string?> userAgentArch;

    public string? UserAgentArch => this.userAgentArch.Value;

    #endregion

    #region User Agent Bitness

    private readonly Lazy<string?> userAgentBitness;

    public string? UserAgentBitness => this.userAgentBitness.Value;

    #endregion

    #region User Agent Full Version

    private readonly Lazy<string?> userAgentFullVersion;

    public string? UserAgentFullVersion => this.userAgentFullVersion.Value;

    #endregion

    #region User Agent Full Version List

    private readonly Lazy<string?> userAgentFullVersionList;

    public string? UserAgentFullVersionList => this.userAgentFullVersionList.Value;

    #endregion

    #region User Agent Mobile

    private readonly Lazy<string?> userAgentMobile;

    public string? UserAgentMobile => this.userAgentMobile.Value;

    #endregion

    #region Device Pixel Ratio

    private readonly Lazy<double?> devicePixelRatio;

    public double? DevicePixelRatio => this.devicePixelRatio.Value;

    #endregion

    #region Model

    private readonly Lazy<string?> userAgentModel;

    public string? UserAgentModel => this.userAgentModel.Value;

    #endregion

    #region Platform

    private readonly Lazy<string?> userAgentPlatform;

    public string? UserAgentPlatform => this.userAgentPlatform.Value;

    #endregion

    #region Platform Version

    private readonly Lazy<Version?> userAgentPlatformVersion;

    public Version? UserAgentPlatformVersion => this.userAgentPlatformVersion.Value;

    #endregion

    #region Viewport Width

    private readonly Lazy<int?> viewportWidth;

    public int? ViewportWidth => this.viewportWidth.Value;

    #endregion

    #region Viewport Height

    private readonly Lazy<int?> viewportHeight;

    public int? ViewportHeight => this.viewportHeight.Value;

    #endregion

    protected ClientHintsResolver()
    {
        this.userAgent = new Lazy<string?>(this.GetUserAgent);
        this.userAgentArch = new Lazy<string?>(this.GetUserAgentArch);
        this.userAgentBitness = new Lazy<string?>(this.GetUserAgentBitness);
        this.userAgentFullVersion = new Lazy<string?>(this.GetUserAgentFullVersion);
        this.userAgentFullVersionList = new Lazy<string?>(this.GetUserAgentFullVersionList);
        this.userAgentMobile = new Lazy<string?>(this.GetUserAgentMobile);
        this.devicePixelRatio = new Lazy<double?>(this.GetDevicePixelRatio);
        this.userAgentModel = new Lazy<string?>(this.GetModel);
        this.userAgentPlatform = new Lazy<string?>(this.GetPlatform);
        this.userAgentPlatformVersion = new Lazy<Version?>(this.GetPlatformVersion);
        this.viewportWidth = new Lazy<int?>(this.GetViewportWidth);
        this.viewportHeight = new Lazy<int?>(this.GetViewportHeight);
    }

    public ClientHintsResolver(IDictionary<string, string> headers) : this()
    {
        this.headers = headers;
    }

    public ClientHintsResolver(IHeaderDictionary? headerDictionary) : this()
    {
        this.headerDictionary = headerDictionary;
    }

    private string? GetUserAgent()
    {
        if (this.headerDictionary is not null)
        {
            return this.headerDictionary[RequestHeaderNames.UserAgent].FirstOrDefault();
        }

        if (this.headers is not null && this.headers.TryGetValue(RequestHeaderNames.UserAgent, out var value))
        {
            return value;
        }

        return null;
    }

    private string? GetUserAgentArch()
    {
        if (this.headerDictionary is not null)
        {
            return this.headerDictionary[RequestHeaderNames.UserAgentArch].FirstOrDefault();
        }

        if (this.headers is not null && this.headers.TryGetValue(RequestHeaderNames.UserAgentArch, out var value))
        {
            return value;
        }

        return null;
    }

    private string? GetUserAgentBitness()
    {
        if (this.headerDictionary is not null)
        {
            return this.headerDictionary[RequestHeaderNames.UserAgentBitness].FirstOrDefault();
        }

        if (this.headers is not null && this.headers.TryGetValue(RequestHeaderNames.UserAgentBitness, out var value))
        {
            return value;
        }

        return null;
    }

    private string? GetUserAgentFullVersion()
    {
        if (this.headerDictionary is not null)
        {
            return this.headerDictionary[RequestHeaderNames.UserAgentFullVersion].FirstOrDefault();
        }

        if (this.headers is not null && this.headers.TryGetValue(RequestHeaderNames.UserAgentFullVersion, out var value))
        {
            return value;
        }

        return null;
    }

    private string? GetUserAgentFullVersionList()
    {
        if (this.headerDictionary is not null)
        {
            return this.headerDictionary[RequestHeaderNames.UserAgentFullVersionList].FirstOrDefault();
        }

        if (this.headers is not null && this.headers.TryGetValue(RequestHeaderNames.UserAgentFullVersionList, out var value))
        {
            return value;
        }

        return null;
    }

    private string? GetUserAgentMobile()
    {
        if (this.headerDictionary is not null)
        {
            return this.headerDictionary[RequestHeaderNames.UserAgentMobile].FirstOrDefault();
        }

        if (this.headers is not null && this.headers.TryGetValue(RequestHeaderNames.UserAgentMobile, out var value))
        {
            return value;
        }

        return null;
    }

    private double? GetDevicePixelRatio()
    {
        if (this.headerDictionary is not null &&
            double.TryParse(this.headerDictionary[RequestHeaderNames.DevicePixelRatio].FirstOrDefault(), out var headerDictionaryValue))
        {
            return headerDictionaryValue;
        }

        if (this.headers is not null &&
            this.headers.TryGetValue(RequestHeaderNames.DevicePixelRatio, out _) &&
            double.TryParse(this.headers[RequestHeaderNames.DevicePixelRatio], out var headersValue))
        {
            return headersValue;
        }

        return null;
    }

    private string? GetModel()
    {
        if (this.headerDictionary is not null)
        {
            return this.headerDictionary[RequestHeaderNames.UserAgentModel].FirstOrDefault();
        }

        if (this.headers is not null && this.headers.TryGetValue(RequestHeaderNames.UserAgentModel, out var headersValue))
        {
            return ClientHintsHelpers.GetClientHintsValueFromString(headersValue);
        }

        return null;
    }

    private string? GetPlatform()
    {
        if (this.headerDictionary is not null)
        {
            return this.headerDictionary[RequestHeaderNames.UserAgentPlatform].FirstOrDefault();
        }

        if (this.headers is not null && this.headers.TryGetValue(RequestHeaderNames.UserAgentPlatform, out var headersValue))
        {
            return ClientHintsHelpers.GetClientHintsValueFromString(headersValue);
        }

        return null;
    }

    private Version? GetPlatformVersion()
    {
        if (this.headerDictionary is not null &&
            VersionHelpers.TryParseSafe(ClientHintsHelpers.GetClientHintsValueFromString(
                this.headerDictionary[RequestHeaderNames.PlatformVersion].FirstOrDefault()), out var headerDictionaryVersion))
        {
            return headerDictionaryVersion;
        }

        if (this.headers != null && 
            this.headers.TryGetValue(RequestHeaderNames.PlatformVersion, out var value) &&
            VersionHelpers.TryParseSafe(ClientHintsHelpers.GetClientHintsValueFromString(value), out var headersVersion))
        {
            return headersVersion;
        }

        return null;
    }

    private int? GetViewportWidth() => this.GetIntValue(RequestHeaderNames.ViewportWidth);

    private int? GetViewportHeight() => this.GetIntValue(RequestHeaderNames.ViewportHeight);

    private int? GetIntValue(string name)
    {
        if (this.headerDictionary is not null && int.TryParse(this.headerDictionary[name].FirstOrDefault(), out var headerDictionaryValue))
        {
            return headerDictionaryValue;
        }

        if (this.headers is not null && this.headers.TryGetValue(name, out var value) && int.TryParse(value, out var headersValue))
        {
            return headersValue;
        }

        return null;
    }
}
