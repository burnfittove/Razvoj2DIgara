using UnityEngine;

public class PlayerBullet : Bullet
{
    
     private void SetScaleFromDamage(float damage)
     {
         var scale = 0.0f;
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
}
