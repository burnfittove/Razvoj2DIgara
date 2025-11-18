using PlayerScripts;
using Unity.VisualScripting;
using UnityEngine;

namespace Enemies
{
    public abstract class Enemy: MonoBehaviour, IDamageable
    {
        // Attributes
        public EnemyInformationSO enemyInfo;
        protected Attribute Health;
        protected Attribute Speed;
        protected Attribute Damage;
        protected Attribute FireDelay;
        protected Attribute Range;
        protected Attribute ShotSpeed;
        protected Attribute ContactDamage;
        // Other attributes
        protected bool isInvisible;
        // Components
        protected Rigidbody2D rb;
        protected Collider2D cc;
        protected SpriteRenderer sr;
        
        protected virtual void Awake()
        {
            rb = GetComponent<Rigidbody2D>();
            sr = GetComponentInChildren<SpriteRenderer>();
            cc = GetComponent<Collider2D>();
            
            // # Attributes
            // ## Health
            Health = new Attribute(enemyInfo.health, 1, 1, 1, 0, enemyInfo.health);
            // ## Speed
            Speed = new Attribute(enemyInfo.speed, 1, 1, 1, 1, enemyInfo.speed);
            // ## Damage
            Damage = new Attribute(enemyInfo.damage, 1, 1, 1, 0, enemyInfo.damage);
            // ## Fire Delay
            FireDelay = new Attribute(enemyInfo.fireDelay, 1, 1, 1, 0, enemyInfo.fireDelay);
            // ## Range
            Range = new Attribute(enemyInfo.range,  1, 1, 1, 0, enemyInfo.shotSpeed);
            // ## Shot Speed
            ShotSpeed = new Attribute(enemyInfo.shotSpeed, 1, 1, 1, 0, enemyInfo.shotSpeed);
            
            if (isInvisible) sr.enabled = false;
        }

        public void TakeDamage(float damage)
        {
            Health.UpdateValue(-damage);
        }

        protected virtual void OnDeath()
        {
            Destroy(gameObject);
        }

        private void Update()
        {
            if (Health.Value <= 0) OnDeath();
        }

        protected virtual void Move(Vector2 direction)
        {
            rb.linearVelocity = direction * (Speed.Value * Time.fixedDeltaTime);
        }
    }
}
