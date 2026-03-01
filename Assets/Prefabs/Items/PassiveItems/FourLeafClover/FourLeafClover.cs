using Events;
using Item.PassiveItem;

namespace Prefabs.Items.PassiveItems.FourLeafClover
{
    public class FourLeafClover : PassiveItem
    {
        protected override void OnItemPickedUp()
        {
            GameEventManager.Instance.attributeUpdateEvents.LuckMultiplierChange(itemInformation.luckMultiplierDelta);
            base.OnItemPickedUp();
        }
    }
}
