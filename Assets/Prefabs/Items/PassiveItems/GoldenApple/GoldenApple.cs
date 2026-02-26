using Item.PassiveItem;

namespace Prefabs.Items.PassiveItems.GoldenApple
{
    public class GoldenApple : PassiveItem
    {
        protected override void OnItemPickedUp()
        {
            ChangeMaxHealth(itemInformation.maxHealthDelta);
            ChangeSpeed(itemInformation.speedDelta);
            base.OnItemPickedUp();
        }
    }
}
