using Microsoft.Extensions.DependencyInjection;

namespace Optivify.BrowserDetection.AspNetCore.DependencyInjection
{
    public class DetectionBuilder : IDetectionBuilder
    {
        public IServiceCollection Services { get; }

        public DetectionBuilder(IServiceCollection services)
        {
            Services = services;
        }
    }
}
