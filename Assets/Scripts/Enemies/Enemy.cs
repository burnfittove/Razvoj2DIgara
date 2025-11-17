using System;
using PlayerScripts;
using Unity.VisualScripting;
using UnityEngine;

namespace Enemies
{
    public abstract class Enemy: MonoBehaviour, IDamageable
    {
        public EnemyInformationSO enemyInfo;
        protected Rigidbody2D rb;
        protected SpriteRenderer sr;
        protected Player p;
        protected bool isInvisible;
        
        protected virtual void Awake()
        {
            rb = GetComponent<Rigidbody2D>();
            p = FindFirstObjectByType<Player>();
            sr = GetComponent<SpriteRenderer>();
            
            if (isInvisible) sr.enabled = false;
        }

        public void TakeDamage(float damage)
        {
            enemyInfo.health -= damage;
        }

        protected virtual void OnDeath()
        {
            Destroy(gameObject);
        }

        private void Update()
        {
            if (enemyInfo.health <= 0) OnDeath();
        }

        protected virtual void Move(Vector2 direction)
        {
            rb.linearVelocity = direction * (enemyInfo.speed * Time.fixedDeltaTime);
        }
    }
}
