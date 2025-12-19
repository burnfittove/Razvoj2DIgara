using System;
using Items;
using UnityEngine;

public class ItemEvents
{
    public event Action<GameObject> OnPassiveItemAcquired;
    public void PassiveItemAcquired(GameObject item)
    {
        OnPassiveItemAcquired?.Invoke(item);
    }
    
    public event Action<Item> OnNearbyItemDetected;
    public void NearbyItemDetected(Item item)
    {
        OnNearbyItemDetected?.Invoke(item);
    }
    
    public event Action OnNearbyItemLost;

    public void NearbyItemLost()
    {
        OnNearbyItemLost?.Invoke();
    }
}
