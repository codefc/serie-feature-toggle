using FeatureToggle.Toggles.Contract;

namespace FeatureToggle.Toggles
{
    public class CardAFeatureToggle : IFeatureToggle
    {
        public string GetToggleName()
        {
            return FeatuteToggleNames.CARD_A;
        }
    }
}