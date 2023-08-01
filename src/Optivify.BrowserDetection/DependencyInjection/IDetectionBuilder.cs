using Microsoft.Extensions.DependencyInjection;

namespace Optivify.BrowserDetection.DependencyInjection;

public interface IDetectionBuilder
{
    IServiceCollection Services { get; }
}
