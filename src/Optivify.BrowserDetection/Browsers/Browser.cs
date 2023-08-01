namespace Optivify.BrowserDetection.Browsers;

public class Browser : IBrowser
{
    public string Name { get; }

    public Version Version { get; }

    public Browser(string name, Version version)
    {
        this.Name = name;
        this.Version = version;
    }

    public override string ToString()
    {
        return $"{this.Name}-{this.Version}";
    }
}
