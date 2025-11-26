using System;
using Events;
using UnityEngine;

namespace Items.ItemEffects
{
    public abstract class PassiveItemEffect : MonoBehaviour
    {
        public ItemInformationSO itemInformation;
        public bool isPersistent = false;

        private void Start()
        {
            if (!isPersistent) Destroy(gameObject);
        }
        
        // Base attributes
        protected void ChangeHealth(float newHealth)
        {
            GameEventManager.Instance.AttributeUpdateEvents.HealthChange(newHealth);
        }

        protected void ChangeSpeed(float newSpeed)
        {
            GameEventManager.Instance.AttributeUpdateEvents.SpeedChange(newSpeed);
        }
        
        protected void ChangeDamage(float newDamage)
        {
            GameEventManager.Instance.AttributeUpdateEvents.DamageChange(newDamage);
        }

        protected void ChangeFireDelay(float newFireRate)
        {
            GameEventManager.Instance.AttributeUpdateEvents.FireDelayChange(newFireRate);
        }

        protected void ChangeRange(float newRange)
        {
            GameEventManager.Instance.AttributeUpdateEvents.RangeChange(newRange);
        }

        protected void ChangeShotSpeed(float newShotSpeed)
        {
            GameEventManager.Instance.AttributeUpdateEvents.ShotSpeedChange(newShotSpeed);
        }

        protected void ChangeLuck(float newLuck)
        {
            GameEventManager.Instance.AttributeUpdateEvents.LuckChange(newLuck);
        }
        
        // Attribute multipliers
        protected void ChangeSpeedMultiplier(float newSpeedMultiplier)
        {
            GameEventManager.Instance.AttributeUpdateEvents.SpeedMultiplierChange(newSpeedMultiplier);
        }
        
        protected void ChangeDamageMultiplier(float newDamageMultiplier)
        {
            GameEventManager.Instance.AttributeUpdateEvents.DamageMultiplierChange(newDamageMultiplier);
        }
        
        protected void ChangeFireDelayMultiplier(float newFireRateMultiplier)
        {
            GameEventManager.Instance.AttributeUpdateEvents.FireDelayMultiplierChange(newFireRateMultiplier);
        }

        protected void ChangeRangeMultiplier(float newRangeMultiplier)
        {
            GameEventManager.Instance.AttributeUpdateEvents.RangeMultiplierChange(newRangeMultiplier);
        }

        protected void ChangeLuckMultiplier(float newLuckMultiplier)
        {
            GameEventManager.Instance.AttributeUpdateEvents.LuckMultiplierChange(newLuckMultiplier);
        }
        
        // Other attributes
        protected void ChangeKnockbackStrength(float newKnockbackStrength)
        {
            GameEventManager.Instance.AttributeUpdateEvents.KnockbackChange(newKnockbackStrength);
        }

        protected void ChangeContactDamage(float newContactDamage)
        {
            GameEventManager.Instance.AttributeUpdateEvents.ContactDamageChange(newContactDamage);
        }
    }
}