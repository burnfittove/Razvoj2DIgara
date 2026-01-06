using Item.PassiveItem;

namespace Prefabs.Items.PassiveItems.Mitosis
{
    public class Mitosis : PassiveItem
    {
        protected override void OnItemPickedUp()
        {
            ChangeMaxHealth(itemInformation.maxHealthDelta);
            base.OnItemPickedUp();
        }
    }
}
