using PlayerScripts;
using UnityEngine;

namespace Enemies
{
    public abstract class Enemy: MonoBehaviour, IDamageable
    {
        public EnemyInformationSO enemyInfo;
        protected Rigidbody2D rb;
        protected Collider2D cc;
        protected SpriteRenderer sr;
        protected Player p;
        protected bool isInvisible;
        protected Attribute Health;
        protected Attribute Speed;
        
        protected virtual void Awake()
        {
            rb = GetComponent<Rigidbody2D>();
            p = FindFirstObjectByType<Player>();
            sr = GetComponentInChildren<SpriteRenderer>();
            cc = GetComponent<Collider2D>();
            
            // # Attributes
            // ## Health
            Health = new Attribute(enemyInfo.health, 1, 1, 1, 0, enemyInfo.health);
            // ## Speed
            Speed = new Attribute(enemyInfo.speed, 1, 1, 1, 1, enemyInfo.speed);
            
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
