using Events;

namespace Currencies.Money
{
    public class Coin : Pickup
    {
        protected override void OnPickupPickedUp()
        {
            GameEventManager.Instance.pickupEvents.CurrencyPickUp(value);
            Destroy(gameObject);
        }
    }
}