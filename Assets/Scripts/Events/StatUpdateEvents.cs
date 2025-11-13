using System;

namespace Events
{
    public class StatUpdateEvents
    {
        public event Action<float> OnHealthChange;
        public void HealthChange(float value)
        {
            OnHealthChange?.Invoke(value);
        }
    
        public event Action<float> OnDamageChange;
        public void DamageChange(float value)
        {
            OnDamageChange?.Invoke(value);
        }
        
        public event Action<float> OnDamageMultiplierChange;

        public void DamageMultiplierChange(float value)
        {
            OnDamageMultiplierChange?.Invoke(value);
        }
        
        public event Action<float> OnFireDelayChange;

        public void FireDelayChange(float value)
        {
            OnFireDelayChange?.Invoke(value);
        }
        
        public event Action<float> OnFireDelayMultiplierChange;

        public void FireDelayMultiplierChange(float value)
        {
            OnFireDelayMultiplierChange?.Invoke(value);
        }
        
        public event  Action<float> OnSpeedChange;

        public void SpeedChange(float value)
        {
            OnSpeedChange?.Invoke(value);
        }
    }
}
