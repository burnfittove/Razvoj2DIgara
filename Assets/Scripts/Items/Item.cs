using System;
using Events;
using UnityEngine;

namespace Items
{
    public abstract class Item : MonoBehaviour
    {
        protected CircleCollider2D cc;
        public ItemInformationSO itemInfo;

        private void Awake()
        {
            cc = GetComponent<CircleCollider2D>();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.tag != "Player") return;
            UpdatePlayerHealth(itemInfo.maxHealthDelta);
            UpdatePlayerDamage(itemInfo.damageDelta);
            UpdatePlayerDamageMultiplier(itemInfo.damageMultiplierDelta);
            UpdatePlayerFireRate(itemInfo.fireDelayDelta);
            UpdatePlayerFireRateMultiplier(itemInfo.fireRateMultiplierDelta);
            UpdatePlayerSpeed(itemInfo.speedDelta);
            UpdatePlayerBulletLifetime(itemInfo.rangeDelta);
            ItemEffect();
            Destroy(gameObject);
        }

        private void UpdatePlayerHealth(float newHealth)
        {
            GameEventManager.Instance.AttributeUpdateEvents.HealthChange(newHealth);
        }

        private void UpdatePlayerDamage(float newDamage)
        {
            GameEventManager.Instance.AttributeUpdateEvents.DamageChange(newDamage);
        }

        private void UpdatePlayerDamageMultiplier(float newDamageMultiplier)
        {
            GameEventManager.Instance.AttributeUpdateEvents.DamageMultiplierChange(newDamageMultiplier);
        }

        private void UpdatePlayerFireRate(float newFireRate)
        {
            GameEventManager.Instance.AttributeUpdateEvents.FireDelayChange(newFireRate);
        }

        private void UpdatePlayerFireRateMultiplier(float newFireRateMultiplier)
        {
            GameEventManager.Instance.AttributeUpdateEvents.FireDelayMultiplierChange(newFireRateMultiplier);
        }

        private void UpdatePlayerSpeed(float newSpeed)
        {
            GameEventManager.Instance.AttributeUpdateEvents.SpeedChange(newSpeed);
        }

        private void UpdatePlayerBulletLifetime(float newBulletLifetime)
        {
            GameEventManager.Instance.AttributeUpdateEvents.RangeChange(newBulletLifetime);
        }
        
        protected virtual void ItemEffect() {}
    }
}
