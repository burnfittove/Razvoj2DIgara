using Item.PassiveItem;

namespace Prefabs.Items.PassiveItems.MikuMikuBeam
{
    public class MikuMikuBeam : PassiveItem
    {
        protected override void OnItemPickedUp()
        {
            ChangeSpeed(itemInformation.speedDelta);
            ChangeShotSpeed(itemInformation.shotSpeedDelta);
            ChangeDamageMultiplier(itemInformation.damageMultiplierDelta);
            ChangeFireDelayMultiplier(itemInformation.fireDelayMultiplierDelta);
            base.OnItemPickedUp();
        }
    }
}
