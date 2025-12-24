using System;

namespace Events
{
    public class PickupEvents
    {
        
        public event Action<int> OnCurrencyPickUp;
        public void CurrencyPickUp(int amount)
        {
            OnCurrencyPickUp?.Invoke(amount);
        }
        public event Action<int> OnSoulPickUp;
        public void SoulPickUp(int amount)
        {
            OnSoulPickUp?.Invoke(amount);
        }
    }
}
