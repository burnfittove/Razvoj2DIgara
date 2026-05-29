using System;
using Events;
using Item.ActiveItem;
using UnityEngine;
using UnityEngine.InputSystem;

namespace PlayerScripts
{
    public class Player : MonoBehaviour, IDamageable
    {
        [Header("Attributes")]
        [SerializeField] private PlayerInformationSo playerInformation;
        
        [Header("State-Independent Values")]
        public Vector2 MovementDirection { get; set; }
        public float FireDelayBuffer { get; set; }
        public bool IsFiring { get; set; }
        public Vector2 FireDirection { get; set; }

        [Header("Components")]
        [HideInInspector] public Rigidbody2D rb;
        public SpriteRenderer sr;
        [HideInInspector] public Animator animator;

        public AudioClip hurtSound;
        public AudioClip deathSound;

        private void Awake()
        {
            // # Components
            // ## Rigidbody
            TryGetComponent(out rb);
            if (!sr) sr = GetComponentInChildren<SpriteRenderer>();
            TryGetComponent(out animator);
        }

        private void OnEnable()
        {
            // Subscribe to attribute change events
            // Active Item
            GameEventManager.Instance.itemEvents.OnActiveItemAcquired += ChangeActiveItem;
            GameEventManager.Instance.inputEvents.OnActiveItemUsed += UseActiveItem;
        }

        // #################
        // ##### Items #####
        // #################
        private void ChangeActiveItem(GameObject newActiveItem)
        {
            // // If the player doesn't have an active item, give them the new one
            // if (!ActiveItem)
            // {
            //     ActiveItem = newActiveItem;
            //     return;
            // }
            //
            // // If they do, switch them out; first create the old active item them set the new one
            // GameEventManager.Instance.itemEvents.CreateItemById(ActiveItem, (Vector2)transform.position + Vector2.one * Random.Range(1, 1.4f));
            // ActiveItem = newActiveItem;
            // Overrides the active item and removes the old one
            // ActiveItem = newActiveItem;
            PlayerInfo.Instance.SetActiveItem(newActiveItem);
        }
        
        private void UseActiveItem(InputAction.CallbackContext ctx)
        {
            if (!ctx.started) return;
            if (!PlayerInfo.Instance.ActiveItem) return;
            var temp = PlayerInfo.Instance.ActiveItem.GetComponent<ActiveItem>();
            if (temp.currentCharge < temp.itemInformation.maxCharge) return;
            temp.UseActiveItem();
        }

        public void DecreaseInvincibilityDuration()
        {
            if (PlayerInfo.Instance.InvincibilityDuration.value < 0) return;
            PlayerInfo.Instance.InvincibilityDuration.UpdateValue(-Time.deltaTime);
        }

        // IDamageable
        public void TakeDamage(float damage)
        {
            // If the player is supposed to be invincible, return
            if (PlayerInfo.Instance.InvincibilityDuration.value > 0) return;
            
            // Take damage
            GameEventManager.Instance.attributeUpdateEvents.HealthChange(-damage);
            
            // Make sound
            GameEventManager.Instance.audioEvents.PlaySound(hurtSound);
            
            // Set invincibility timer
            PlayerInfo.Instance.InvincibilityDuration.UpdateValue(playerInformation.invincibilityDuration);
        }

        public void TakeContactDamage(float damage)
        {
            TakeDamage(damage);
        }

        private void OnCollisionStay2D(Collision2D other)
        {
            // Damage enemies
            if (other.gameObject.CompareTag("Enemy") && other.gameObject.TryGetComponent<IDamageable>(out var damageable) && PlayerInfo.Instance.ContactDamage.value > 0) damageable.TakeContactDamage(PlayerInfo.Instance.ContactDamage.value);
        }
    }
}
