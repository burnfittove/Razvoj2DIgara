using System;
using Items;
using UnityEngine;

public class MagicOnion : Item
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            UpdatePlayerFireRateMultiplier(itemInfo.fireRateMultiplierDelta);
            UpdatePlayerDamageMultiplier(itemInfo.damageMultiplierDelta);
            Destroy(gameObject);
        }
    }
}
