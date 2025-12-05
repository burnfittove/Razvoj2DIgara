using Items.ItemEffects;

namespace Items.PassiveItems.QuickCast
{
    public class QuickCastEffect : PassiveItemEffect
    {
        protected override void Awake()
        {
            ChangeFireDelay(itemInformation.fireDelayDelta);
        }
    }
}