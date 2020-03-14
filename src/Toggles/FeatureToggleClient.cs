using System.Threading.Tasks;
using ConfigCat.Client;
using FeatureToggle.Toggles.Contract;

namespace FeatureToggle.Toggles
{
    public class FeatureToggleClient : IFeatureToggleClient
    {
        private readonly IConfigCatClient _configCatClient;

        public FeatureToggleClient(IConfigCatClient configCatClient)
        {
            _configCatClient = configCatClient;
        }

        public bool IsValid(IFeatureToggle toggle)
        {
            return GetValue(toggle.GetToggleName());
        }

        public bool IsValid(string toggle)
        {
            return GetValue(toggle);
        }

        public async Task<bool> IsValidAsync(IFeatureToggle toggle)
        {
            return await GetValueAsync(toggle.GetToggleName());
        }

        public async Task<bool> IsValidAsync(string toggle)
        {
            return await GetValueAsync(toggle);
        }

        private async Task<bool> GetValueAsync(string toggleName)
        {
            await _configCatClient.ForceRefreshAsync();

            return await _configCatClient.GetValueAsync(toggleName, false);
        }

         private bool GetValue(string toggleName)
        {
            _configCatClient.ForceRefresh();

            return _configCatClient.GetValue(toggleName, false);
        }
    }
}