using PlayerScripts;
using UnityEngine;

namespace Item.PassiveItem
{
    public abstract partial class PassiveItem : Item
    {
        protected Player player;
        private SpriteRenderer spriteRenderer;
        private Collider2D circleCollider;

        private void Awake()
        {
            TryGetComponent(out spriteRenderer);
            TryGetComponent(out circleCollider);
            GameObject.FindWithTag("Player").TryGetComponent(out player);
        }

        /// <summary>
        /// OnItemPickedUp runs when the player touches the item. This method must be overriden and any attribute changes or event subscriptions need to be handled before base.OnItemPickedUp
        /// </summary>
        protected override void OnItemPickedUp()
        {
            if (!ItemInformation.isPersistantPassive) Destroy(gameObject);
            spriteRenderer.enabled = false;
            circleCollider.enabled = false;
            transform.SetParent(player.transform);
        }
    }
}