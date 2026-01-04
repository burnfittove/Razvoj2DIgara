using System;
using Events;
using Unity.VisualScripting;
using UnityEngine;

namespace Item
{
    public abstract class Item : MonoBehaviour
    {
        [SerializeField] protected ItemInformationSo itemInformation;
        public ItemInformationSo ItemInformation => itemInformation;
        public bool isBuyable = false;


        private void Start()
        {
            if (itemInformation.price == 0) itemInformation.price = itemInformation.itemQuality * 1000;
            if (itemInformation.demonPrice == 0) itemInformation.demonPrice = itemInformation.itemQuality * 10;
        }

        protected abstract void OnItemPickedUp();

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.CompareTag("Player")) return;
            if (isBuyable) GameEventManager.Instance.pickupEvents.CurrencyPickUp(-itemInformation.price);
            OnItemPickedUp();
        }
    }
}