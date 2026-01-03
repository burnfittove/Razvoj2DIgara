using Item.PassiveItem;

namespace Prefabs.Items.PassiveItems.MikuMikuBeam
{
    public class MikuMikuBeam : PassiveItem
    {
        protected override void OnItemPickedUp()
        {
            ChangeSpeed(ItemInformation.speedDelta);
            ChangeShotSpeed(ItemInformation.shotSpeedDelta);
            ChangeDamageMultiplier(ItemInformation.damageMultiplierDelta);
            ChangeFireDelayMultiplier(ItemInformation.fireDelayMultiplierDelta);
            base.OnItemPickedUp();
        }
    }
}
