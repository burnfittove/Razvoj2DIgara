using System;
using Events;
using PlayerScripts;
using UnityEngine;
using UnityEngine.Rendering.Universal;

namespace Item
{
    [Serializable]
    public abstract class Item : MonoBehaviour
    {
        public ItemInformationSo itemInformation;
        [HideInInspector] public bool isBuyable = false;
        [HideInInspector] public bool meetsPickUpRequirements;
        protected SpriteRenderer spriteRenderer;
        protected Collider2D coll;
        protected Player player;
        private Light2D itemLight;

        protected virtual void Awake()
        {
            // Get references
            TryGetComponent(out spriteRenderer);
            TryGetComponent(out coll);
            itemLight = GetComponentInChildren<Light2D>();
            GameObject.FindWithTag("Player").TryGetComponent(out player);
            
            if (itemInformation.price == 0) itemInformation.price = itemInformation.itemQuality * 1000;
            if (itemInformation.vampirePrice == 0) itemInformation.vampirePrice = itemInformation.itemQuality * 10;
            meetsPickUpRequirements = true;
        }

        private void Start()
        {
            if (itemLight) itemLight.color = spriteRenderer.color;
            Debug.Log(itemLight);
        }

        protected virtual void OnItemPickedUp()
        {
            GameEventManager.Instance.audioEvents.PlaySound(GameEventManager.Instance.audioEvents.GetItemSound());
            TryGetComponent(out Animator animator);
            if (animator) animator.enabled = false;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.CompareTag("Player")) return;
            if (!meetsPickUpRequirements) return;
            if (itemLight) itemLight.enabled = false;
            OnItemPickedUp();
        }

        protected virtual void HideItem()
        {
            spriteRenderer.enabled = false;
            coll.enabled = false;
        }
    }
}