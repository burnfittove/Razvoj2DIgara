using Item.PassiveItem;

namespace Items.PassiveItems.QuickCast
{
    public class QuickCast : PassiveItem
    {
        protected override void OnItemPickedUp()
        {
            ChangeFireDelay(ItemInformation.fireDelayDelta);
            base.OnItemPickedUp();
        }
    }
}