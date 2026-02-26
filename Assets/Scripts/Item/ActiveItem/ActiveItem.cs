using Events;
using UnityEngine;

namespace Item.ActiveItem
{
    public abstract class ActiveItem : Item
    {
        public int currentCharge;
        protected override void OnItemPickedUp()
        {
            GameEventManager.Instance.itemEvents.ActiveItemAcquired(gameObject);
            GameEventManager.Instance.roomEvents.OnRoomCleared += IncreaseCharge;
            HideItem();
            
            // Set item parent to player so it doesn't disappear
            transform.SetParent(player.transform);
        }

        protected override void Awake()
        {
            base.Awake();
            currentCharge = itemInformation.maxCharge;
        }

        public virtual void UseActiveItem()
        {
            // If the item is not fully charged, return
            if (currentCharge != itemInformation.maxCharge) return;
            
            // Otherwise, the item has been used and it should set its charge to zero
            currentCharge = 0;
        }

        protected virtual void IncreaseCharge()
        {
            currentCharge += 1;
        }
    }
}
