using System;
using Items.ItemEffects;

namespace Items.QuickCast
{
    public class QuickCastEffect : PassiveItemEffect
    {
        private void Awake()
        {
            ChangeFireDelay(itemInformation.fireDelayDelta);
        }
    }
}