using Events;
using UnityEngine;

namespace Items
{
    public class Item : MonoBehaviour
    {
        protected CircleCollider2D cc;
        public ItemInformationSO itemInfo;

        private void Awake()
        {
            cc = GetComponent<CircleCollider2D>();
        }
    
        protected void UpdatePlayerHealth(float newHealth)
        {
            GameEventManager.Instance.statUpdateEvents.HealthChange(newHealth);
        }

        protected void UpdatePlayerDamage(float newDamage)
        {
            GameEventManager.Instance.statUpdateEvents.DamageChange(newDamage);
        }

        protected void UpdatePlayerDamageMulitplier(float newDamageMultiplier)
        {
            GameEventManager.Instance.statUpdateEvents.DamageMultiplierChange(newDamageMultiplier);
        }

        protected void UpdatePlayerFireRate(float newFireRate)
        {
            GameEventManager.Instance.statUpdateEvents.FireDelayChange(newFireRate);
        }
        
        protected void UpdatePlayerFireRateMultiplier(float newFireRateMultiplier)
        {
            GameEventManager.Instance.statUpdateEvents.FireDelayMultiplierChange(newFireRateMultiplier);
        }

        protected void UpdatePlayerSpeed(float newSpeed)
        {
            GameEventManager.Instance.statUpdateEvents.SpeedChange(newSpeed);
        }
    }
}
