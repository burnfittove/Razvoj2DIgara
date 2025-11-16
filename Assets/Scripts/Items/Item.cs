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
            UpdatePlayerHealth(itemInfo.healthDelta);
            UpdatePlayerDamage(itemInfo.damageDelta);
            UpdatePlayerDamageMultiplier(itemInfo.damageMultiplierDelta);
            UpdatePlayerFireRate(itemInfo.fireDelayDelta);
            UpdatePlayerFireRateMultiplier(itemInfo.fireRateMultiplierDelta);
            UpdatePlayerSpeed(itemInfo.speedDelta);
            UpdatePlayerBulletLifetime(itemInfo.bulletLifetimeDelta);
            ItemEffect();
            Destroy(gameObject);
        }

        private void UpdatePlayerHealth(float newHealth)
        {
            GameEventManager.Instance.StatUpdateEvents.HealthChange(newHealth);
        }

        private void UpdatePlayerDamage(float newDamage)
        {
            GameEventManager.Instance.StatUpdateEvents.DamageChange(newDamage);
        }

        private void UpdatePlayerDamageMultiplier(float newDamageMultiplier)
        {
            GameEventManager.Instance.StatUpdateEvents.DamageMultiplierChange(newDamageMultiplier);
        }

        private void UpdatePlayerFireRate(float newFireRate)
        {
            GameEventManager.Instance.StatUpdateEvents.FireDelayChange(newFireRate);
        }

        private void UpdatePlayerFireRateMultiplier(float newFireRateMultiplier)
        {
            GameEventManager.Instance.StatUpdateEvents.FireDelayMultiplierChange(newFireRateMultiplier);
        }

        private void UpdatePlayerSpeed(int newSpeed)
        {
            GameEventManager.Instance.StatUpdateEvents.SpeedChange(newSpeed);
        }

        private void UpdatePlayerBulletLifetime(float newBulletLifetime)
        {
            GameEventManager.Instance.StatUpdateEvents.LifetimeChange(newBulletLifetime);
        }
        
        protected virtual void ItemEffect() {}
    }
}
