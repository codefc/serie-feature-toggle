using FeatureToggle.Toggles.Contract;

namespace FeatureToggle.Toggles
{
    public class CardBFeatureToggle : IFeatureToggle
    {
        public string GetToggleName()
        {
            return FeatuteToggleNames.CARD_B;
        }
    }
}