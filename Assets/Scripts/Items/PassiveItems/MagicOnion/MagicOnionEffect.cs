using Items.ItemEffects;

namespace Items.PassiveItems.MagicOnion
{
    public class MagicOnionEffect : PassiveItemEffect
    {
        protected override void Awake()
        {
            ChangeDamageMultiplier(itemInformation.damageMultiplierDelta);
            ChangeFireDelayMultiplier(itemInformation.fireDelayMultiplierDelta);
        }
    }
}
