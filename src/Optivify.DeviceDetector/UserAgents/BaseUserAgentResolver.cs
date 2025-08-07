namespace Optivify.DeviceDetector.UserAgents;

public abstract class BaseUserAgentResolver : IUserAgentResolver
{
    public const string UserAgentHeaderName = "User-Agent";

    public string? UserAgent { get; protected set; }
}
