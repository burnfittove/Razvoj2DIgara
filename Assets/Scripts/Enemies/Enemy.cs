using UnityEngine;

namespace Enemies
{
    public abstract class Enemy: MonoBehaviour, IDamageable
    {
        public float Health { get; private set; }
        public float MaxHealth { get; private set; }
        public float Damage { get; private set; }
        public float Speed { get; private set; }
        private Rigidbody2D rb;

        private void Awake()
        {
            rb = GetComponent<Rigidbody2D>();
        }

        public void TakeDamage(float damage)
        {
            Health -= damage;
        }

        private void OnDeath()
        {
            Destroy(gameObject);
        }

        private void FixedUpdate()
        {
            Move(Vector2.right);
        }

        private void Move(Vector2 direction)
        {
            rb.linearVelocity = direction * (Speed * Time.fixedDeltaTime);
        }
    }
}
