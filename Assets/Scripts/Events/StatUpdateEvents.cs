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
    }
}
