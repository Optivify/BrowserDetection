using Microsoft.Extensions.DependencyInjection;

namespace Optivify.BrowserDetection.AspNetCore.DependencyInjection
{
    public interface IDetectionBuilder
    {
        IServiceCollection Services { get; }
    }
}
