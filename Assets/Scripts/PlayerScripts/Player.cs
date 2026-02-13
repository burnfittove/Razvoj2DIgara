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

        [Header("Visible Attributes")] 
        public Attribute MaxHealth { get; private set; }
        public Attribute Health { get; private set; }

        public Attribute Speed { get; private set; }

        public Attribute Damage { get; private set; }

        public Attribute FireDelay { get; private set; }

        public Attribute Range { get; private set; }

        public Attribute ShotSpeed { get; private set; }

        public Attribute Luck { get; private set; }

        [Header("Hidden Attributes")]
        public Attribute KnockbackStrength { get; private set; }
        public Attribute ContactDamage { get; private set; }
        public Attribute InvincibilityDuration { get; private set; }
        [Header("Currencies")]
        public Attribute Money { get; private set; }
        public Attribute Souls { get; private set; }
        [Header("Constraints")]
        private float maxSpeed;
        private float minValue;
        private float minMultiplier;
        private float maxMultiplier;
        
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
            
            // # Initialize attributes
            // ## Constraints 
            maxSpeed = playerInformation.maxSpeed;
            minValue = playerInformation.minValue;
            minMultiplier = playerInformation.minMultiplier;
            maxMultiplier = playerInformation.maxMultiplier;
            // ## Visible Attributes
            // ### Health
            MaxHealth = new Attribute(playerInformation.health, 1, minMultiplier, maxMultiplier, 0, playerInformation.maxHealth);
            Health = new Attribute(playerInformation.health, 1, minMultiplier, maxMultiplier, 0, MaxHealth.Value);
            // ### Speed
            Speed = new Attribute(playerInformation.speed, playerInformation.speedMultiplier, minMultiplier, maxMultiplier, 3, playerInformation.maxSpeed);
            // ### Damage
            Damage = new Attribute(playerInformation.damage, playerInformation.damageMultiplier, minMultiplier, maxMultiplier, minValue, float.MaxValue);
            // ### Fire Delay
            FireDelay = new Attribute(playerInformation.fireDelay, playerInformation.fireDelayMultiplier,minMultiplier,  maxMultiplier, minValue, 100);
            // ### Range
            Range = new Attribute(playerInformation.range, playerInformation.rangeMultiplier, minMultiplier,  maxMultiplier, minValue, 10);
            // ### Shot speed
            ShotSpeed = new Attribute(playerInformation.shotSpeed, 1, minMultiplier, maxMultiplier, minValue, 50);
            // ### Luck
            Luck = new Attribute(playerInformation.luck, playerInformation.luckMultiplier, minMultiplier,  maxMultiplier, minValue, float.MaxValue);
            // ## Hidden Attributes
            // ### Knockback strength
            KnockbackStrength = new Attribute(playerInformation.knockbackStrength, 1, minMultiplier, maxMultiplier, minValue, 10);
            // ### Contact damage
            ContactDamage = new Attribute(playerInformation.contactDamage, 1, minMultiplier, maxMultiplier, minValue, float.MaxValue);
            // ### Invincibility Duration
            InvincibilityDuration = new Attribute(playerInformation.invincibilityDuration, 1, 1, 1, -10, 10);
            // ## Currencies
            // ### Money
            Money = new Attribute(0, 1, minMultiplier, maxMultiplier, 0, float.MaxValue);
            // ### Souls
            Souls = new Attribute(0, 1, minMultiplier, maxMultiplier, 0, float.MaxValue);
        }

        private void OnEnable()
        {
            // Subscribe to attribute change events
            // Regular
            GameEventManager.Instance.attributeUpdateEvents.OnMaxHealthChange += UpdateMaxHealth;
            GameEventManager.Instance.attributeUpdateEvents.OnHealthChange += UpdateHealth;
            GameEventManager.Instance.attributeUpdateEvents.OnSpeedChange += UpdateSpeed;
            GameEventManager.Instance.attributeUpdateEvents.OnDamageChange += UpdateDamage;
            GameEventManager.Instance.attributeUpdateEvents.OnFireDelayChange += UpdateFireDelay;
            GameEventManager.Instance.attributeUpdateEvents.OnRangeChange += UpdateRange;
            GameEventManager.Instance.attributeUpdateEvents.OnShotSpeedChange += UpdateShotSpeed;
            GameEventManager.Instance.attributeUpdateEvents.OnLuckChange += UpdateLuck;
            GameEventManager.Instance.attributeUpdateEvents.OnKnockbackChange += UpdateKnockbackStrength;
            GameEventManager.Instance.attributeUpdateEvents.OnContactDamageChange += UpdateContactDamage;
            // Multipliers
            GameEventManager.Instance.attributeUpdateEvents.OnSpeedMultiplierChange += UpdateSpeedMultiplier;
            GameEventManager.Instance.attributeUpdateEvents.OnDamageMultiplierChange += UpdateDamageMultiplier;
            GameEventManager.Instance.attributeUpdateEvents.OnFireDelayMultiplierChange += UpdateFireDelayMultiplier;
            GameEventManager.Instance.attributeUpdateEvents.OnRangeMultiplierChange += UpdateRangeMultiplier;
            GameEventManager.Instance.attributeUpdateEvents.OnLuckMultiplierChange += UpdateLuckMultiplier;
            // Currencies
            GameEventManager.Instance.pickupEvents.OnCurrencyPickUp += UpdateMoney;
            GameEventManager.Instance.pickupEvents.OnSoulPickUp += UpdateSouls;
            GameEventManager.Instance.attributeUpdateEvents.OnMoneyChange += UpdateMoney;
            GameEventManager.Instance.attributeUpdateEvents.OnSoulChange += UpdateSouls;
            // Active Item
            GameEventManager.Instance.itemEvents.OnActiveItemAcquired += ChangeActiveItem;
            GameEventManager.Instance.inputEvents.OnActiveItemUsed += UseActiveItem;
        }

        // ######################
        // ##### Attributes #####
        // ######################
        private void UpdateMaxHealth(float value)
        {
            MaxHealth.UpdateValue(value);
            Health.ChangeConstantMaxValue(MaxHealth.Value);
            Health.UpdateValue(value);
        }
        private void UpdateHealth(float value)
        {
            Health.UpdateValue(value);
        }
        private void UpdateSpeed(float value)
        {
            Speed.UpdateValue(value);
        }
        private void UpdateDamage(float value)
        {
            Damage.UpdateValue(value);
        }
        private void UpdateFireDelay(float value)
        {
            FireDelay.UpdateValue(value);
        }
        private void UpdateRange(float value)
        {
            Range.UpdateValue(value);
        }
        private void UpdateShotSpeed(float value)
        {
            ShotSpeed.UpdateValue(value);
        }
        private void UpdateLuck(float value)
        {
            Luck.UpdateValue(value);
        }
        private void UpdateKnockbackStrength(float value)
        {
            KnockbackStrength.UpdateValue(value);
        }
        private void UpdateContactDamage(float value)
        {
            ContactDamage.UpdateValue(value);
        }
    
        // Multipliers
        private void UpdateSpeedMultiplier(float value)
        {
            Speed.UpdateMultiplier(value);
        }
        private void UpdateDamageMultiplier(float value)
        {
            Damage.UpdateMultiplier(value);
        }
        private void UpdateFireDelayMultiplier(float value)
        {
            FireDelay.UpdateMultiplier(value);
        }
        private void UpdateRangeMultiplier(float value)
        {
            Range.UpdateMultiplier(value);
        }
        private void UpdateLuckMultiplier(float value)
        {
            Luck.UpdateMultiplier(value);
        }
        
        // Currencies
        private void UpdateMoney(int value)
        {
            Money.UpdateValue(value);
        }
        private void UpdateSouls(int value)
        {
            Souls.UpdateValue(value);
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
            if (InvincibilityDuration.Value < 0) return;
            InvincibilityDuration.UpdateValue(-Time.deltaTime);
        }

        private void Update()
        {
            // Decrease the invincibility timer
            // DecreaseInvincibilityDuration();
        }

        // IDamageable
        public void TakeDamage(float damage)
        {
            // If the player is supposed to be invincible, return
            if (InvincibilityDuration.Value > 0) return;
            
            // Take damage
            GameEventManager.Instance.attributeUpdateEvents.HealthChange(damage);
            
            // Set invincibility timer
            InvincibilityDuration.UpdateValue(playerInformation.invincibilityDuration);
        }
    }
}
