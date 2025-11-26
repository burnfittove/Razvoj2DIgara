using System;
using Items.ItemEffects;
namespace Items.GrowthHormones
{
    public class GrowthHormonesEffect : PassiveItemEffect
    {
        private void Awake()
        {
            ChangeHealth(itemInformation.maxHealthDelta);
            ChangeSpeed(itemInformation.speedDelta);
            ChangeDamage(itemInformation.damageDelta);
        }
    }
}
