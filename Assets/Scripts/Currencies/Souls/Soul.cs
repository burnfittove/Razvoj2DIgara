using Events;
using UnityEngine;

namespace Currencies.Souls
{
    public class Soul : Pickup
    {
        [SerializeField] private AudioClip soulPickupSound;
        
        protected override void OnPickupPickedUp()
        {
            GameEventManager.Instance.pickupEvents.SoulPickUp(value);
            GameEventManager.Instance.audioEvents.PlaySound(soulPickupSound);
            Destroy(gameObject);
        }
    }
}