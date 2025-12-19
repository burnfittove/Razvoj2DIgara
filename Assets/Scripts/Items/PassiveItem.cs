using Events;
using UnityEngine;

namespace Items
{
    public class PassiveItem : Item
    {
        public GameObject itemEffectPrefab;
        protected override void OnItemPickedUp()
        {
            GameEventManager.Instance.itemEvents.PassiveItemAcquired(itemEffectPrefab);
            Destroy(gameObject);
        }
    }
}