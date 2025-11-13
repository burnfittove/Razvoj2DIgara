using System;

namespace Events
{
    public class StatUpdateEvents
    {
        // Health update
        public event Action<float> OnHealthChange;
        public void HealthChange(float value)
        {
            OnHealthChange?.Invoke(value);
        }
    
        // Damage update
        public event Action<float> OnDamageChange;
        public void DamageChange(float value)
        {
            OnDamageChange?.Invoke(value);
        }
        
        // Damage multiplier update
        public event Action<float> OnDamageMultiplierChange;

        public void DamageMultiplierChange(float value)
        {
            OnDamageMultiplierChange?.Invoke(value);
        }
        
        // Fire delay update
        public event Action<float> OnFireDelayChange;

        public void FireDelayChange(float value)
        {
            OnFireDelayChange?.Invoke(value);
        }
        
        // Fire delay multiplier update
        public event Action<float> OnFireDelayMultiplierChange;

        public void FireDelayMultiplierChange(float value)
        {
            OnFireDelayMultiplierChange?.Invoke(value);
        }
        
        // Speed update
        public event Action<int> OnSpeedChange;

        public void SpeedChange(int value)
        {
            OnSpeedChange?.Invoke(value);
        }
        
        // Range (bullet lifetime) update
        public event Action<float> OnLifetimeChange;
        public void LifetimeChange(float value)
        {
            OnLifetimeChange?.Invoke(value);
        }
    }
}
