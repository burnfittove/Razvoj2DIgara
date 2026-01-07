using System;
using Managers;
using UnityEngine;

namespace Events
{
    public class ItemEvents
    {
        public event Action<GameObject> OnPassiveItemAcquired;
        public void PassiveItemAcquired(GameObject item)
        {
            OnPassiveItemAcquired?.Invoke(item);
        }
        
        public event Action<GameObject> OnActiveItemAcquired;
        public void ActiveItemAcquired(GameObject item)
        {
            OnActiveItemAcquired?.Invoke(item);
        }
    
        public event Action<Item.Item> OnNearbyItemDetected;
        public void NearbyItemDetected(Item.Item item)
        {
            OnNearbyItemDetected?.Invoke(item);
        }
    
        public event Action OnNearbyItemLost;
        public void NearbyItemLost()
        {
            OnNearbyItemLost?.Invoke();
        }

        public event Action<ItemPool> OnCreateItemFromPool;
        public void CreateItemFromPool(ItemPool itemPool)
        {
            OnCreateItemFromPool?.Invoke(itemPool);
        }
    }
}
