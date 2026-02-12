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

        public event Func<ItemPool, GameObject> OnGetItemFromPool;
        public GameObject GetItemFromPool(ItemPool itemPool)
        {
            return OnGetItemFromPool?.Invoke(itemPool);
        }

        public event Action<GameObject, Vector2> OnCreateItemById; // TODO: Also turn this into Func<GameObject/int, GameObject>

        public void CreateItemById(GameObject item, Vector2 position)
        {
            OnCreateItemById?.Invoke(item, position);
        }
        
        public event Func<GameObject> OnGetPenny; // The item manager then creates the penny
        public virtual GameObject GetPenny()
        {
            return OnGetPenny?.Invoke();
        }
    }
}
