using System;
using Events;
using PlayerScripts;
using UnityEngine;
using Attribute = PlayerScripts.Attribute;

namespace Merchants
{
    public class ShopItem : MonoBehaviour
    {
        private Attribute playerMoney;
        private Collider2D col;
        private Item.Item item;
        
        private void Awake()
        {
            playerMoney = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().Money;
            TryGetComponent(out col);
            TryGetComponent(out item);
            
            SetColliderState();
            
            GameEventManager.Instance.pickupEvents.OnCurrencyPickUp += _ => SetColliderState();
        }

        private void SetColliderState()
        {
            col.enabled = item.ItemInformation.price <= playerMoney.Value;
        }
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.CompareTag("Player")) return;
            GameEventManager.Instance.pickupEvents.CurrencyPickUp(-item.ItemInformation.price);
        }
    }
}
