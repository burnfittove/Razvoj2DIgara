using UnityEngine;

public class PlayerShooter : MonoBehaviour, IShooter
{
    private Player p;

    void Awake()
    {
        p = GetComponentInParent<Player>();
    }
    
    public void Shoot(Vector2 direction)
    {
        // Exit if there is still fire delay
        if (p.FireDelayBuffer > 0) return;
        // Exit if the player is not in the movment or idle state

        // Stuff
        Debug.Log($"Fire!!");
        var bulletToFire = Instantiate(p.Bullet, p.transform.position, Quaternion.identity);
        bulletToFire.GetComponent<Bullet>().Initialize(direction, p.BulletSpeed, p.BulletDamage, p.BulletRange);

        // Set fire delay
        p.FireDelayBuffer = p.fireDelay;
    }
}
