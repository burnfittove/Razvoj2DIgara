using System.Collections;
using Events;
using UnityEngine;

namespace Item.ActiveItem
{
    public class ActiveItem : Item
    {
        protected override void OnItemPickedUp()
        {
            GameEventManager.Instance.itemEvents.ActiveItemAcquired(gameObject);
            HideItem();
        }
    }
}
