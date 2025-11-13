using Events;
using UnityEngine;

namespace Items
{
    public partial class Item : MonoBehaviour
    {
        private CircleCollider2D cc;
        private ItemInformationSO itemInfo;

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

        protected void UpdatePlayerFireRate(float newFireRate)
        {
            GameEventManager.Instance.statUpdateEvents.FireRateChange(newFireRate);
        }

        protected void UpdatePlayerSpeed(float newSpeed)
        {
            GameEventManager.Instance.statUpdateEvents.SpeedChange(newSpeed);
        }

        protected void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                // Run methods based on whether the item changes a stat
            }
        }
    }
}
