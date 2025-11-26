using System;
using Events;
using UnityEngine;

namespace Items
{
    public abstract class Item : MonoBehaviour
    {
        public ItemInformationSO itemInformation;
        private SpriteRenderer sr;

        private void Awake()
        {
            // Get components
            sr = GetComponent<SpriteRenderer>();
        }

        private void Start()
        {
            //sr.sprite = itemInformation.itemSprite;
        }

        protected abstract void OnItemPickedUp();

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.tag != "Player") return;
            OnItemPickedUp();
        }
    }
}
