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
        
        public event Action<float> OnFireRateChange;

        public void FireRateChange(float value)
        {
            OnFireRateChange?.Invoke(value);
        }
        
        public event  Action<float> OnSpeedChange;

        public void SpeedChange(float value)
        {
            OnSpeedChange?.Invoke(value);
        }
    }
}
