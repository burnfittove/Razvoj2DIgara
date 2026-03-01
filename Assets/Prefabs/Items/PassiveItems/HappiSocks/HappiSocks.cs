using Item.PassiveItem;

namespace Prefabs.Items.PassiveItems.HappiSocks
{
    public class HappiSocks : PassiveItem
    {
        protected override void OnItemPickedUp()
        {
            ChangeSpeed(itemInformation.speedDelta);
            base.OnItemPickedUp();
        }
    }
}
