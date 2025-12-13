using Items.ItemEffects;

namespace Items.PassiveItems.GrowthHormones
{
    public class GrowthHormonesEffect : PassiveItemEffect
    {
        protected override void Awake()
        {
            ChangeMaxHealth(itemInformation.maxHealthDelta);
            ChangeSpeed(itemInformation.speedDelta);
            ChangeDamage(itemInformation.damageDelta);
        }
    }
}
