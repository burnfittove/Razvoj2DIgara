using System;
using Items.ItemEffects;

namespace Items.HappiSocks
{
    public class HappiSocksEffect : PassiveItemEffect
    {
        private void Awake()
        {
            ChangeSpeed(itemInformation.speedDelta);
        }
    }
}
