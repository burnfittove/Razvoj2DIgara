using Events;
using UnityEngine;

namespace Bullets
{
    [RequireComponent(typeof(Rigidbody2D))]
    public abstract class Bullet : MonoBehaviour
    {
        protected Rigidbody2D rb;
        protected Vector2 moveDirection;
        protected float moveSpeed;
        protected float damage;
        protected float lifetime;
        protected IDamageable damageable;
        private Vector3 baseScale;
        public AudioClip disappearSound;

        private void Awake()
        {
            // Initialize components
            rb = GetComponent<Rigidbody2D>();
            
            baseScale = transform.localScale;
        }

        private void Update()
        {
            DecreaseLifetime();
        }

        private void FixedUpdate()
        {
            Move();
        }

        // When the bullet is enables, pass it some values
        public virtual void Initialize(Vector2 dir, float speed, float damage, float lifetime)
        {
            // Reset scale
            transform.localScale = baseScale;
            dir.Normalize();
            moveDirection = dir;
            moveSpeed = speed;
            this.damage = damage;
            this.lifetime = lifetime;
        }
        
        // Same thing but can also change the scale (used by enemies)
        public virtual void Initialize(Vector2 dir, float speed, float damage, float lifetime, float scale)
        {
            // Reset scale
            transform.localScale = baseScale;
            dir.Normalize();
            moveDirection = dir;
            moveSpeed = speed;
            this.damage = damage;
            this.lifetime = lifetime;
            // Increase the scale
            transform.localScale *= scale;
        }

        private void Move()
        {
            rb.MovePosition((Vector2)transform.position + moveDirection * (Time.fixedDeltaTime * moveSpeed));
        }

        private void DecreaseLifetime()
        {
            lifetime -= Time.deltaTime * 10;

            if (lifetime > 0) return;
            GameEventManager.Instance.audioEvents.PlaySoundWithRandomPitch(disappearSound);
            gameObject.SetActive(false);
        }

        protected virtual void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.CompareTag("Wall")) return;
            GameEventManager.Instance.audioEvents.PlaySoundWithRandomPitch(disappearSound);
            gameObject.SetActive(false);
        }
    }
}
