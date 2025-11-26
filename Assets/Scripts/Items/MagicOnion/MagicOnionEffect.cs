using System;
using Items.ItemEffects;

namespace Items.MagicOnion
{
    public class MagicOnionEffect : PassiveItemEffect
    {
        private void Awake()
        {
            ChangeDamageMultiplier(itemInformation.damageMultiplierDelta);
            ChangeFireDelayMultiplier(itemInformation.fireDelayMultiplierDelta);
        }
    }
}
