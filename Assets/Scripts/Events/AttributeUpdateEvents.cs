using System;

namespace Events
{
    public class AttributeUpdateEvents
    {
        // # Attributes
        // ## Regular
        // ### Health
        public event Action<float> OnMaxHealthChange;

        public void MaxHealthChange(float value)
        {
            OnMaxHealthChange?.Invoke(value);
        }
        public event Action<float> OnHealthChange;
        public void HealthChange(float value)
        {
            OnHealthChange?.Invoke(value);
        }
    
        // ### Speed
        public event Action<float> OnSpeedChange;

        public void SpeedChange(float value)
        {
            OnSpeedChange?.Invoke(value);
        }
        
        // ### Damage
        public event Action<float> OnDamageChange;
        public void DamageChange(float value)
        {
            OnDamageChange?.Invoke(value);
        }
        
        // ### Fire delay
        public event Action<float> OnFireDelayChange;

        public void FireDelayChange(float value)
        {
            OnFireDelayChange?.Invoke(value);
        }
        
        // ### Range 
        public event Action<float> OnRangeChange;
        public void RangeChange(float value)
        {
            OnRangeChange?.Invoke(value);
        }
        
        // ### Shot speed
        public event Action<float> OnShotSpeedChange;
        public void ShotSpeedChange(float value)
        {
            OnShotSpeedChange?.Invoke(value);
        }
        
        // ### Luck
        public event Action<float> OnLuckChange;
        public void LuckChange(float value)
        {
            OnLuckChange?.Invoke(value);
        }
        
        // ### Knockback
        public event Action<float> OnKnockbackChange;
        public void KnockbackChange(float value)
        {
            OnKnockbackChange?.Invoke(value);
        }
        
        // ### Contact damage
        public event Action<float> OnContactDamageChange;
        public void ContactDamageChange(float value)
        {
            OnContactDamageChange?.Invoke(value);
        }
        
        // ## Multipliers
        // ### Speed Multiplier
        public event Action<float> OnSpeedMultiplierChange;

        public void SpeedMultiplierChange(float value)
        {
            OnSpeedMultiplierChange?.Invoke(value);
        }
        
        // ### Damage Multiplier
        public event Action<float> OnDamageMultiplierChange;

        public void DamageMultiplierChange(float value)
        {
            OnDamageMultiplierChange?.Invoke(value);
        }
        
        // ### Fire delay
        public event Action<float> OnFireDelayMultiplierChange;

        public void FireDelayMultiplierChange(float value)
        {
            OnFireDelayMultiplierChange?.Invoke(value);
        }
        
        // ### Range Multiplier
        public event Action<float> OnRangeMultiplierChange;

        public void RangeMultiplierChange(float value)
        {
            OnRangeMultiplierChange?.Invoke(value);
        }
        
        // ### Luck Multiplier
        public event Action<float> OnLuckMultiplierChange;

        public void LuckMultiplierChange(float value)
        {
            OnLuckMultiplierChange?.Invoke(value);
        }
    }
}
