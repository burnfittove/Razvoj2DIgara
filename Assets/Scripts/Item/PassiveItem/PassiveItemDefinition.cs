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

        protected override void OnItemPickedUp()
        {
            if (!ItemInformation.isPersistantPassive) Destroy(gameObject);
            spriteRenderer.enabled = false;
            circleCollider.enabled = false;
            transform.SetParent(player.transform);
        }
    }
}