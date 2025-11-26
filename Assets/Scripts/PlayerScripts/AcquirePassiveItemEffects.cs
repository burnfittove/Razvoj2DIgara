using System;
using Events;
using UnityEngine;

namespace PlayerScripts
{
    public class AcquirePassiveItemEffects : MonoBehaviour
    {
        private void OnEnable()
        {
            // Passive item acquisition
            GameEventManager.Instance.ItemPickupEvents.OnPassiveItemAcquired += InstantiatePassiveItemEffect;
        }

        // Passive item effect
        private void InstantiatePassiveItemEffect(GameObject passiveItem)
        {
            var obj = Instantiate(passiveItem, transform.position, Quaternion.identity);
            obj.transform.SetParent(transform);
        }
    }
}