using FeatureToggle.Config;
using Microsoft.Extensions.DependencyInjection;
using ConfigCat.Client;
using Microsoft.Extensions.Configuration;

namespace FeatureToggle.Extensions
{
    public static class ConfigCatExtensions
    {
        public static void AddConfigCat(this IServiceCollection service, IConfiguration configuration)
        {
            // Get ConfigCatOptions Config
            ConfigCatOptions configCatOptions = new ConfigCatOptions();
            configuration.Bind(nameof(ConfigCatOptions), configCatOptions);

            service.AddScoped<IConfigCatClient>(factory => new ConfigCatClient(configCatOptions.Key));
        }
    }
}