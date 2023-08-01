using Microsoft.Extensions.DependencyInjection;

namespace Optivify.BrowserDetection.DependencyInjection;

public class DetectionBuilder : IDetectionBuilder
{
    public IServiceCollection Services { get; }

    public DetectionBuilder(IServiceCollection services)
    {
        this.Services = services;
    }
}
