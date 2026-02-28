using System;
using Events;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace PlayerScripts
{
    /// <summary>
    /// PlayerInfo holds data regarding the player and modifies it when certain events are invoked.
    /// </summary>
    [Serializable]
    public class PlayerInfo : MonoBehaviour//, ICloneable
    {
        // Singleton
        public static PlayerInfo Instance { get; private set; }
        
        // PlayerInformationSO
        public PlayerInformationSo playerInformation;

        // Attributes
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
        public bool canFly = false;
        [Header("Currencies")]
        public Attribute Money { get; private set; }
        public Attribute Souls { get; private set; }
        [Header("Constraints")]
        private float maxSpeed;
        private float minValue;
        private float minMultiplier;
        private float maxMultiplier;
        
        
        private void Awake()
        {
            // Singleton
            if (Instance != null && Instance != this) Debug.LogError("Multiple instances of GameEventManager detected!");
            Instance = this;
            
            // Set attributes
            InitializeAttributes(playerInformation);
        }

        private void OnEnable()
        {
            // Set event handlers for attribute changes
            InitializeEventHandlers();
        }

        private void InitializeEventHandlers()
        {
            // Subscribe to attribute change events
            // Regular
            GameEventManager.Instance.attributeUpdateEvents.OnMaxHealthChange += UpdateOnMaxHealth;
            GameEventManager.Instance.attributeUpdateEvents.OnHealthChange += UpdateOnHealth;
            GameEventManager.Instance.attributeUpdateEvents.OnSpeedChange += UpdateOnSpeed;
            GameEventManager.Instance.attributeUpdateEvents.OnDamageChange += UpdateOnDamage;
            GameEventManager.Instance.attributeUpdateEvents.OnFireDelayChange += UpdateOnFireDelay;
            GameEventManager.Instance.attributeUpdateEvents.OnRangeChange += UpdateOnRange;
            GameEventManager.Instance.attributeUpdateEvents.OnShotSpeedChange += UpdateOnShotSpeed;
            GameEventManager.Instance.attributeUpdateEvents.OnLuckChange += UpdateOnLuck;
            GameEventManager.Instance.attributeUpdateEvents.OnKnockbackChange += UpdateOnKnockbackStrength;
            GameEventManager.Instance.attributeUpdateEvents.OnContactDamageChange += UpdateOnContactDamage;
            // Multipliers
            GameEventManager.Instance.attributeUpdateEvents.OnSpeedMultiplierChange += UpdateOnSpeedMultiplier;
            GameEventManager.Instance.attributeUpdateEvents.OnDamageMultiplierChange += UpdateOnDamageMultiplier;
            GameEventManager.Instance.attributeUpdateEvents.OnFireDelayMultiplierChange += UpdateOnFireDelayMultiplier;
            GameEventManager.Instance.attributeUpdateEvents.OnRangeMultiplierChange += UpdateRangeMultiplier;
            GameEventManager.Instance.attributeUpdateEvents.OnLuckMultiplierChange += UpdateLuckMultiplier;
            // Currencies
            GameEventManager.Instance.pickupEvents.OnCurrencyPickUp += UpdateMoney;
            GameEventManager.Instance.pickupEvents.OnSoulPickUp += UpdateSouls;
            GameEventManager.Instance.attributeUpdateEvents.OnMoneyChange += UpdateMoney;
            GameEventManager.Instance.attributeUpdateEvents.OnSoulChange += UpdateSouls;
        }

        private void InitializeAttributes(PlayerInformationSo info)
        {
            // # Initialize attributes
            // ## Constraints 
            maxSpeed = info.maxSpeed;
            minValue = info.minValue;
            minMultiplier = info.minMultiplier;
            maxMultiplier = info.maxMultiplier;
            // ## Visible Attributes
            // ### Health
            MaxHealth = new Attribute(info.health, 1, minMultiplier, maxMultiplier, 0, info.maxHealth);
            Health = new Attribute(info.health, 1, minMultiplier, maxMultiplier, 0, MaxHealth.value);
            // ### Speed
            Speed = new Attribute(info.speed, info.speedMultiplier, minMultiplier, maxMultiplier, 3, info.maxSpeed);
            // ### Damage
            Damage = new Attribute(info.damage, info.damageMultiplier, minMultiplier, maxMultiplier, minValue, float.MaxValue);
            // ### Fire Delay
            FireDelay = new Attribute(info.fireDelay, info.fireDelayMultiplier,minMultiplier,  maxMultiplier, minValue, 100);
            // ### Range
            Range = new Attribute(info.range, info.rangeMultiplier, minMultiplier,  maxMultiplier, minValue, 500);
            // ### Shot speed
            ShotSpeed = new Attribute(info.shotSpeed, 1, minMultiplier, maxMultiplier, minValue, 50);
            // ### Luck
            Luck = new Attribute(info.luck, info.luckMultiplier, minMultiplier,  maxMultiplier, minValue, float.MaxValue);
            // ## Hidden Attributes
            // ### Knockback strength
            KnockbackStrength = new Attribute(info.knockbackStrength, 1, minMultiplier, maxMultiplier, minValue, 10);
            // ### Contact damage
            ContactDamage = new Attribute(info.contactDamage, 1, minMultiplier, maxMultiplier, minValue, float.MaxValue);
            // ### Invincibility Duration
            InvincibilityDuration = new Attribute(info.invincibilityDuration, 1, 1, 1, -10, 10);
            // ## Currencies
            // ### Money
            Money = new Attribute(0, 1, minMultiplier, maxMultiplier, 0, float.MaxValue);
            // ### Souls
            Souls = new Attribute(0, 1, minMultiplier, maxMultiplier, 0, float.MaxValue);
        }

        
        
        // Attribute updates
        private void UpdateOnMaxHealth(float value)
        {
            MaxHealth.UpdateValue(value);
            Health.ChangeConstantMaxValue(MaxHealth.value);
            Health.UpdateValue();
        }
        private void UpdateOnHealth(float value)
        {
            Health.UpdateValue(value);
        }
        private void UpdateOnSpeed(float value)
        {
            Speed.UpdateValue(value);
        }
        private void UpdateOnDamage(float value)
        {
            Damage.UpdateValue(value);
        }
        private void UpdateOnFireDelay(float value)
        {
            FireDelay.UpdateValue(value);
        }
        private void UpdateOnRange(float value)
        {
            Range.UpdateValue(value);
        }
        private void UpdateOnShotSpeed(float value)
        {
            ShotSpeed.UpdateValue(value);
        }
        private void UpdateOnLuck(float value)
        {
            Luck.UpdateValue(value);
        }
        private void UpdateOnKnockbackStrength(float value)
        {
            KnockbackStrength.UpdateValue(value);
        }
        private void UpdateOnContactDamage(float value)
        {
            ContactDamage.UpdateValue(value);
        }
        
        // Multiplier updates
        private void UpdateOnSpeedMultiplier(float value)
        {
            Speed.UpdateMultiplier(value);
        }
        private void UpdateOnDamageMultiplier(float value)
        {
            Damage.UpdateMultiplier(value);
        }
        private void UpdateOnFireDelayMultiplier(float value)
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
        
        // Currency updates
        private void UpdateMoney(int value)
        {
            Money.UpdateValue(value);
        }
        private void UpdateSouls(int value)
        {
            Souls.UpdateValue(value);
        }
        
        // // Copy
        // public object Clone()
        // {
        //     
        // }
    }
}