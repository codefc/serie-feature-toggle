using System.Threading.Tasks;

namespace  FeatureToggle.Toggles.Contract
{
        public interface IFeatureToggleClient
        {
            Task<bool> IsValidAsync(IFeatureToggle toggle);

            Task<bool> IsValidAsync(string toggle);

            bool IsValid(IFeatureToggle toggle);

            bool IsValid(string toggle);
        }
}   