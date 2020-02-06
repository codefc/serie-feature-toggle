using System.Threading.Tasks;
using FeatureToggle.Models;
using Refit;

namespace FeatureToggle.Service
{
    public interface IDogAPIService
    {
        [Get("/breed/{dogName}/images/random")]
        Task<DogServiceModel> GetDogImage(string dogName);
    }
}