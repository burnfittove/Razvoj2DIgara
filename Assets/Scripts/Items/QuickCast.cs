using System;
using Items;
using UnityEngine;

public class QuickCast : Item
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            UpdatePlayerFireRate(itemInfo.fireDelayDelta);
            Destroy(gameObject);
        }
    }
}