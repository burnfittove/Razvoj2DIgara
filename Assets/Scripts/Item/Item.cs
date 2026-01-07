using System;
using Events;
using PlayerScripts;
using Unity.VisualScripting;
using UnityEngine;

namespace Item
{
    public abstract class Item : MonoBehaviour
    {
        [SerializeField] protected ItemInformationSo itemInformation;
        public ItemInformationSo ItemInformation => itemInformation;
        [HideInInspector] public bool isBuyable = false;
        [HideInInspector] public bool meetsPickUpRequirements;
        protected SpriteRenderer spriteRenderer;
        protected Collider2D coll;
        protected Player player;


        private void Awake()
        {
            // Get references
            TryGetComponent(out spriteRenderer);
            TryGetComponent(out coll);
            GameObject.FindWithTag("Player").TryGetComponent(out player);
            
            if (itemInformation.price == 0) itemInformation.price = itemInformation.itemQuality * 1000;
            if (itemInformation.demonPrice == 0) itemInformation.demonPrice = itemInformation.itemQuality * 10;
            meetsPickUpRequirements = true;
        }

        protected abstract void OnItemPickedUp();

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.CompareTag("Player")) return;
            if (!meetsPickUpRequirements) return;
            OnItemPickedUp();
        }

        protected virtual void HideItem()
        {
            spriteRenderer.enabled = false;
            coll.enabled = false;
        }
    }
}