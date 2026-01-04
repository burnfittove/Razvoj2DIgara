using Events;
using UnityEngine;

namespace Merchants
{
    public class Shopkeeper : Merchant
    {
        protected override void Awake()
        {
            base.Awake();
            // Disable/enable colliders whenever the player's currencies changes
            GameEventManager.Instance.pickupEvents.OnCurrencyPickUp += _ => InitializeItemStates();
        }

        protected override void InitializeItemStates()
        {
            foreach (var item in items)
            {
                item.GetComponent<Collider2D>().enabled = item.GetComponent<Item.Item>().ItemInformation.price <= player.Money.Value;
                Debug.Log(item.GetComponent<Collider2D>().enabled);
            }
        }
    }
}
