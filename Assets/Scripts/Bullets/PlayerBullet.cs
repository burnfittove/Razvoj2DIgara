using UnityEngine;

namespace Bullets
{
    public class PlayerBullet : Bullet
    {
        private void SetScaleFromDamage(float damage)
        {
            var scale = damage switch
            {
                <= 1 => damage / 2,
                <= 10 => damage / 10,
                _ => damage / 15
            };
            transform.localScale = new Vector3(scale, scale, 1f);
        } 
    
        public override void Initialize(Vector2 dir, float speed, float damage, float lifetime)
        {
            base.Initialize(dir, speed, damage, lifetime);
            SetScaleFromDamage(damage);
        }

        protected override void OnTriggerEnter2D(Collider2D other)
        {
            base.OnTriggerEnter2D(other);
            if (!other.CompareTag("Enemy")) return;
            other.GetComponent<IDamageable>()?.TakeDamage(damage);
            gameObject.SetActive(false);
        }
    }
}
