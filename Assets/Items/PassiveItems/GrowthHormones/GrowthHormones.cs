using Item.PassiveItem;

namespace Items.PassiveItems.GrowthHormones
{
    public class GrowthHormones : PassiveItem
    {
        protected override void OnItemPickedUp()
        {
            ChangeMaxHealth(ItemInformation.maxHealthDelta);
            ChangeSpeed(ItemInformation.speedDelta);
            ChangeFireDelay(ItemInformation.fireDelayDelta);
            base.OnItemPickedUp();
        }
    }
}
