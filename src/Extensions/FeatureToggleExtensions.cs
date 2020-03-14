using FeatureToggle.Toggles;
using FeatureToggle.Toggles.Contract;
using Microsoft.Extensions.DependencyInjection;

namespace FeatureToggle.Extensions
{
    public static class FeatureToggleExtensions
    {
        public static void AddFeatureToggleServices(this IServiceCollection services)
        {
            services.AddScoped<IFeatureToggleClient, FeatureToggleClient>();
        }
    }
}