using System;
using Items;
using UnityEngine;

public class PassiveItemEvents
{
    public event Action<IItemEffect> OnPassiveItemAcquired;

    public void PassiveItemAcquired(IItemEffect item)
    {
        OnPassiveItemAcquired?.Invoke(item);
    }
}
