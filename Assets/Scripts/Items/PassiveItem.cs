using Events;
using UnityEngine;

namespace Items
{
    public class PassiveItem : Item
    {
        public GameObject itemEffectPrefab;
        protected override void OnItemPickedUp()
        {
            GameEventManager.Instance.ItemPickupEvents.PassiveItemAcquired(itemEffectPrefab);
            Destroy(gameObject);
        }
    }
}