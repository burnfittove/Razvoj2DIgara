using Enemies;
using UnityEngine;

namespace Bullets
{
    public class PlayerBullet : Bullet
    {
        private void SetScaleFromDamage(float damage)
        {
            float scale;
            if (damage <= 1) scale = damage / 2;
            else if (damage <= 10) scale = damage / 10;
            else scale = damage / 15;
            transform.localScale = new Vector3(scale, scale, 1f);
        } 
    
        public override void Initialize(Vector2 dir, float speed, float damage, float lifetime)
        {
            dir.Normalize();
            moveDirection = dir;
            moveSpeed = speed;
            this.damage = damage;
            this.lifetime = lifetime;
            SetScaleFromDamage(damage);
        }

        protected override void OnTriggerEnter2D(Collider2D other)
        {
            base.OnTriggerEnter2D(other);
            if (!other.CompareTag("Enemy")) return;
            other.GetComponent<IDamageable>()?.TakeDamage(damage);
            gameObject.SetActive(false);
            Debug.Log($"I hit {other.name}. They have {other.GetComponent<Enemy>().Health.Value} HP left.");
        }
    }
}
