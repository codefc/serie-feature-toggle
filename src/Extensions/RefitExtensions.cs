using FeatureToggle.Config;
using FeatureToggle.Service;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Refit;

namespace FeatureToggle.Extensions
{
    public static class RefitExtension
    {
        public static void AddDogService(this IServiceCollection services, IConfiguration configuration)
        {
            // Get DogServiceOptionsConfig
            DogServiceOptions dogServiceOptions = new DogServiceOptions();
            configuration.Bind(nameof(DogServiceOptions), dogServiceOptions);

            services.AddRefitClient<IDogAPIService>()
                .ConfigureHttpClient(c => c.BaseAddress = new System.Uri(dogServiceOptions.BaseUrl));
        }
    }
}