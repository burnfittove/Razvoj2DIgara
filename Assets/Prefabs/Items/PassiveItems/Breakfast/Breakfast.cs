using Item.PassiveItem;
using UnityEngine;

namespace Prefabs.Items.PassiveItems.Breakfast
{
    public class Breakfast : PassiveItem
    {
        protected override void OnItemPickedUp()
        {
            ChangeMaxHealth(itemInformation.maxHealthDelta);
            base.OnItemPickedUp();
        }
    }
}
