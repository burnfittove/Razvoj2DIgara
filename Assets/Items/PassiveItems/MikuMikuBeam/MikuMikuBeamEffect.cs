using Items.ItemEffects;

namespace Items.PassiveItems.MikuMikuBeam
{
    public class MikuMikuBeamEffect : PassiveItemEffect
    {
        protected override void Awake()
        {
            ChangeSpeed(itemInformation.speedDelta);
            ChangeShotSpeed(itemInformation.shotSpeedDelta);
            ChangeDamageMultiplier(itemInformation.damageMultiplierDelta);
            ChangeFireDelayMultiplier(itemInformation.fireDelayMultiplierDelta);
        }
    }
}