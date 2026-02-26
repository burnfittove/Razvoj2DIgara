using Item.PassiveItem;

namespace Prefabs.Items.PassiveItems.BloodBag
{
    public class BloodBag : PassiveItem
    {
        protected override void OnItemPickedUp()
        {
            ChangeMaxHealth(itemInformation.maxHealthDelta);
            base.OnItemPickedUp();
        }
    }
}