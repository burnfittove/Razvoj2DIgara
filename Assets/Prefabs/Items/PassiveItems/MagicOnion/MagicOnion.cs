using Item.PassiveItem;

namespace Prefabs.Items.PassiveItems.MagicOnion
{
    public class MagicOnion : PassiveItem
    {
        protected override void OnItemPickedUp()
        {
            ChangeDamageMultiplier(itemInformation.damageMultiplierDelta);
            ChangeFireDelayMultiplier(itemInformation.fireDelayMultiplierDelta);
            base.OnItemPickedUp();
        }
    }
}
