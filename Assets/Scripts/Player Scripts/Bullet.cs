using UnityEngine;

public class Bullet: MonoBehaviour
{
    public Bullet(Player player, Vector2 direction)
    {
        p = player;
        this.direction = direction;
    }

    private Player p;
    private Vector2 direction;

    void Update()
    {
        transform.Translate(direction * p.BulletSpeed * Time.deltaTime);
    }
}