using Items;
using UnityEngine;

public class BlackAmulet : Item
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            UpdatePlayerDamage(itemInfo.damageDelta);
            UpdatePlayerBulletLifetime(itemInfo.bulletLifetimeDelta);
            Destroy(gameObject);
        }
    }
}
