using Events;
using Item.PassiveItem;
using UnityEngine;

namespace Prefabs.Items.PassiveItems.Monocle
{
    public class Monocle : PassiveItem
    {
        protected override void OnItemPickedUp()
        {
            ChangeRange(itemInformation.rangeDelta);
            base.OnItemPickedUp();
        }
    }
}
