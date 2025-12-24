using Events;

namespace Currencies.Souls
{
    public class Soul : Pickup
    {
        protected override void OnPickupPickedUp()
        {
            GameEventManager.Instance.pickupEvents.SoulPickUp(value);
            Destroy(gameObject);
        }
    }
}