using Item.PassiveItem;

namespace Items.PassiveItems.MagicOnion
{
    public class MagicOnion : PassiveItem
    {
        protected override void OnItemPickedUp()
        {
            ChangeDamageMultiplier(ItemInformation.damageMultiplierDelta);
            ChangeFireDelayMultiplier(ItemInformation.fireDelayMultiplierDelta);
            base.OnItemPickedUp();
        }
    }
}
