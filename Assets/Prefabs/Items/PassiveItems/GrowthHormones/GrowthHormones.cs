using Item.PassiveItem;

namespace Prefabs.Items.PassiveItems.GrowthHormones
{
    public class GrowthHormones : PassiveItem
    {
        protected override void OnItemPickedUp()
        {
            ChangeMaxHealth(itemInformation.maxHealthDelta);
            ChangeSpeed(itemInformation.speedDelta);
            ChangeFireDelay(itemInformation.fireDelayDelta);
            base.OnItemPickedUp();
        }
    }
}
