using UnityEngine;

/*
This script pools bullets to avoid potenital performance dips due to instatiating during gameplay.
*/

public class PlayerShooter : MonoBehaviour, IShooter
{
    private Player p;
    private BulletPooling bp;

    void Awake()
    {
        p = GetComponent<Player>();
        bp = GetComponent<BulletPooling>();
    }

    public void Shoot(Vector2 direction)
    {
        // Exit if there is still fire delay
        if (p.FireDelayBuffer > 0) return;

        // Use the BulletPooling Script to Instantiate bullets
        Bullet bullet = BulletPooling.SharedInstance.GetPooledObject();
        if (bullet is not null)
        {
            bullet.transform.position = transform.position;
            bullet.Initialize(direction, p.bulletSpeed + p.Velocity, p.bulletDamage, p.bulletLifetime);
            bullet.gameObject.SetActive(true);
        }

        // Set fire delay
        p.FireDelayBuffer = p.fireDelay;
    }
}
