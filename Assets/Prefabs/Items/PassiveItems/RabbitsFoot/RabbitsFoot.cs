using Events;
using Item.PassiveItem;
using UnityEngine;

namespace Prefabs.Items.PassiveItems.RabbitsFoot
{
    public class RabbitsFoot : PassiveItem
    {
        protected override void OnItemPickedUp()
        {
            GameEventManager.Instance.attributeUpdateEvents.LuckChange(itemInformation.luckDelta);
            base.OnItemPickedUp();
        }
    }
}
