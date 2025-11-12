using UnityEngine;

public class PlayerBullet : Bullet
{
    
    /* private void SetScaleFromDamage(float damage)
{
   float scale = math.log(math.pow(damage, 2) * 10) + 5;
   transform.localScale = new Vector3(scale, scale, 1f);
} */

    void OnEnable()
    {
        /* SetScaleFromDamage(damage); */
    }
}
