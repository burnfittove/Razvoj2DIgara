using Item.PassiveItem;

namespace Items.PassiveItems.HappiSocks
{
    public class HappiSocks : PassiveItem
    {
        protected override void OnItemPickedUp()
        {
            ChangeSpeed(ItemInformation.speedDelta);
            base.OnItemPickedUp();
        }
    }
}
