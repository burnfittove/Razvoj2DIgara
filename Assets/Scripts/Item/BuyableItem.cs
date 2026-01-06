using System;
using UnityEngine;
using Attribute = PlayerScripts.Attribute;

namespace Item
{
    public abstract class BuyableItem : MonoBehaviour
    {
        protected Attribute playerAttribute;
        protected Item item;
        
        protected void Awake()
        {
            Initialize();
            item.isBuyable = true;
        }

        protected abstract void Initialize();

        private void LateUpdate()
        {
            SetColliderState();
        }

        protected abstract void SetColliderState();

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.CompareTag("Player")) return;
            if (!item.meetsBuyRequirements) return;
            BuyItem();
        }

        protected abstract void BuyItem();
    }
}
