using Items.ItemEffects;

namespace Items.MikuMikuBeam
{
    public class MikuMikuBeamEffect : PassiveItemEffect
    {
        private void Awake()
        {
            ChangeSpeed(itemInformation.speedDelta);
            ChangeShotSpeed(itemInformation.shotSpeedDelta);
            ChangeDamageMultiplier(itemInformation.damageMultiplierDelta);
            ChangeFireDelayMultiplier(itemInformation.fireDelayMultiplierDelta);
        }
    }
}