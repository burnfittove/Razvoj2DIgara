using System;
using Items;
using UnityEngine;

public class ItemPickupEvents
{
    public event Action<GameObject> OnPassiveItemAcquired;

    public void PassiveItemAcquired(GameObject item)
    {
        OnPassiveItemAcquired?.Invoke(item);
    }
}
