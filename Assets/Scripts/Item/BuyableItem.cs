using System;
using PlayerScripts;
using UnityEngine;
using Attribute = PlayerScripts.Attribute;

namespace Item
{
    public abstract class BuyableItem : MonoBehaviour
    {
        protected Attribute playerAttribute;
        protected Item item;
        
        protected virtual void Awake()
        {
            item.isBuyable = true;
        }

        protected void Initialize(Attribute attribute)
        {
            playerAttribute = attribute;
            TryGetComponent(out item);
        }

        private void LateUpdate()
        {
            SetColliderState();
        }

        protected abstract void SetColliderState();

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.CompareTag("Player")) return;
            if (!item.meetsPickUpRequirements) return;
            BuyItem();
        }

        protected abstract void BuyItem();
    }
}
