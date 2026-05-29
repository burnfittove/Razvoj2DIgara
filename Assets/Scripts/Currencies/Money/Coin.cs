using Events;
using UnityEngine;

namespace Currencies.Money
{
    public class Coin : Pickup
    {
        [SerializeField] private AudioClip coinPickupSound;
        
        protected override void OnPickupPickedUp()
        {
            GameEventManager.Instance.pickupEvents.CurrencyPickUp(value);
            GameEventManager.Instance.audioEvents.PlaySound(coinPickupSound);
            Destroy(gameObject);
        }
    }
}