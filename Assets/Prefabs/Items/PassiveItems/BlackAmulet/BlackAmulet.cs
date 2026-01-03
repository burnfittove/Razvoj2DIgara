using Item.PassiveItem;

namespace Prefabs.Items.PassiveItems.BlackAmulet
{
    public class BlackAmulet : PassiveItem
    {
        protected override void OnItemPickedUp()
        {
            ChangeDamage(itemInformation.damageDelta);
            base.OnItemPickedUp();
        }
    }
}