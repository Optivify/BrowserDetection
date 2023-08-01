namespace Optivify.BrowserDetection.Platforms;

public class Platform : IPlatform
{
    public string PlatformString { get; }

    public string Name { get; }

    public Platform(string platformString, string name)
    {
        this.PlatformString = platformString;
        this.Name = name;
    }

    public override string ToString()
    {
        return this.Name;
    }
}
