using Item.PassiveItem;
using PlayerScripts;

namespace Prefabs.Items.PassiveItems.Scythe
{
    public class Scythe : PassiveItem
    {
        protected override void OnItemPickedUp()
        {
            PlayerInfo.Instance.soulChanceIncrease += 100; // TEMPORARY; CHANGE THIS!!!!
        }
    }
}
