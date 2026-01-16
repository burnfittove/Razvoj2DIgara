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

        // TODO: Change Action<ItemPool>, to Func<ItemPool, GameObject> and use the event when creating an item instead of using an instance of the ItemManager in other scripts
        public event Action<ItemPool> OnCreateItemFromPool;
        public void CreateItemFromPool(ItemPool itemPool)
        {
            OnCreateItemFromPool?.Invoke(itemPool);
        }

        public event Action<GameObject, Vector2> OnCreateItemById;

        public void CreateItemById(GameObject item, Vector2 position)
        {
            OnCreateItemById?.Invoke(item, position);
        }
    }
}
