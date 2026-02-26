using System.ComponentModel;
using UnityEngine;

namespace Bullets
{
    public class EnemyBullet : Bullet
    {
        protected override void OnTriggerEnter2D(Collider2D other)
        {
            base.OnTriggerEnter2D(other);
            if (!other.CompareTag("Player")) return;
            other.GetComponent<IDamageable>()?.TakeDamage(damage);
            gameObject.SetActive(false);
        }
    }
}