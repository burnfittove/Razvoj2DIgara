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
        [Header("Active Item")] 
        public GameObject ActiveItem { get; set; }

        [Header("Components")]
        [HideInInspector] public Rigidbody2D rb;

        private void Awake()
        {
            // # Components
            // ## Rigidbody
            rb = GetComponent<Rigidbody2D>();
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
            ActiveItem = newActiveItem;
        }
        
        private void UseActiveItem(InputAction.CallbackContext ctx)
        {
            if (!ctx.started) return;
            if (!ActiveItem) return;
            var temp = ActiveItem.GetComponent<ActiveItem>();
            if (temp.currentCharge < temp.ItemInformation.maxCharge) return;
            ActiveItem.GetComponent<ActiveItem>().UseActiveItem();
        }

        public void DecreaseInvincibilityDuration()
        {
            if (PlayerInfo.Instance.InvincibilityDuration.Value < 0) return;
            PlayerInfo.Instance.InvincibilityDuration.UpdateValue(-Time.deltaTime);
        }

        // IDamageable
        public void TakeDamage(float damage)
        {
            // If the player is supposed to be invincible, return
            if (PlayerInfo.Instance.InvincibilityDuration.Value > 0) return;
            
            // Take damage
            GameEventManager.Instance.attributeUpdateEvents.HealthChange(-damage);
            
            // Set invincibility timer
            PlayerInfo.Instance.InvincibilityDuration.UpdateValue(playerInformation.invincibilityDuration);
        }
    }
}
