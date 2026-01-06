using Item.PassiveItem;

namespace Prefabs.Items.PassiveItems.Meiosis
{
    public class Meiosis : PassiveItem
    {
        protected override void OnItemPickedUp()
        {
            ChangeMaxHealth(player.MaxHealth.Value);
            ChangeSpeed(itemInformation.speedDelta);
            ChangeDamage(itemInformation.damageDelta);
            ChangeFireDelay(itemInformation.fireDelayDelta);
            ChangeRange(itemInformation.rangeDelta);
            ChangeShotSpeed(itemInformation.shotSpeedDelta);
            ChangeLuck(itemInformation.luckDelta);
            base.OnItemPickedUp();
        }
    }
}
