using System;
using Events;

namespace Item.PassiveItem
{
    [Serializable]
    public abstract partial class PassiveItem
    {
        // Base attributes
        protected void ChangeMaxHealth(float newMaxHealth)
        {
            GameEventManager.Instance.attributeUpdateEvents.MaxHealthChange(newMaxHealth);
            if (itemInformation.healAcquiredHealth) ChangeHealth(newMaxHealth);
        }
        protected void ChangeHealth(float newHealth)
        {
            GameEventManager.Instance.attributeUpdateEvents.HealthChange(newHealth);
        }

        protected void ChangeSpeed(float newSpeed)
        {
            GameEventManager.Instance.attributeUpdateEvents.SpeedChange(newSpeed);
        }
        
        protected void ChangeDamage(float newDamage)
        {
            GameEventManager.Instance.attributeUpdateEvents.DamageChange(newDamage);
        }

        protected void ChangeFireDelay(float newFireRate)
        {
            GameEventManager.Instance.attributeUpdateEvents.FireDelayChange(newFireRate);
        }

        protected void ChangeRange(float newRange)
        {
            GameEventManager.Instance.attributeUpdateEvents.RangeChange(newRange);
        }

        protected void ChangeShotSpeed(float newShotSpeed)
        {
            GameEventManager.Instance.attributeUpdateEvents.ShotSpeedChange(newShotSpeed);
        }

        protected void ChangeLuck(float newLuck)
        {
            GameEventManager.Instance.attributeUpdateEvents.LuckChange(newLuck);
        }
        
        // Attribute multipliers
        protected void ChangeSpeedMultiplier(float newSpeedMultiplier)
        {
            GameEventManager.Instance.attributeUpdateEvents.SpeedMultiplierChange(newSpeedMultiplier);
        }
        
        protected void ChangeDamageMultiplier(float newDamageMultiplier)
        {
            GameEventManager.Instance.attributeUpdateEvents.DamageMultiplierChange(newDamageMultiplier);
        }
        
        protected void ChangeFireDelayMultiplier(float newFireRateMultiplier)
        {
            GameEventManager.Instance.attributeUpdateEvents.FireDelayMultiplierChange(newFireRateMultiplier);
        }

        protected void ChangeRangeMultiplier(float newRangeMultiplier)
        {
            GameEventManager.Instance.attributeUpdateEvents.RangeMultiplierChange(newRangeMultiplier);
        }

        protected void ChangeLuckMultiplier(float newLuckMultiplier)
        {
            GameEventManager.Instance.attributeUpdateEvents.LuckMultiplierChange(newLuckMultiplier);
        }
        
        // Other attributes
        protected void ChangeKnockbackStrength(float newKnockbackStrength)
        {
            GameEventManager.Instance.attributeUpdateEvents.KnockbackChange(newKnockbackStrength);
        }

        protected void ChangeContactDamage(float newContactDamage)
        {
            GameEventManager.Instance.attributeUpdateEvents.ContactDamageChange(newContactDamage);
        }
    }
}