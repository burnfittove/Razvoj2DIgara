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
        [HideInInspector] public bool isBuyable = false;
        [HideInInspector] public bool meetsBuyRequirements;


        private void Awake()
        {
            if (itemInformation.price == 0) itemInformation.price = itemInformation.itemQuality * 1000;
            if (itemInformation.demonPrice == 0) itemInformation.demonPrice = itemInformation.itemQuality * 10;
            meetsBuyRequirements = true;
        }

        protected abstract void OnItemPickedUp();

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.CompareTag("Player")) return;
            if (!meetsBuyRequirements) return;
            OnItemPickedUp();
        }
    }
}