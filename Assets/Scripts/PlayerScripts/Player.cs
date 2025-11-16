using System;
using Events;
using UnityEngine;

namespace PlayerScripts
{
    public class Player : MonoBehaviour
    {
        [Header("Attributes")]
        [SerializeField] private PlayerInformationSO playerInformation;

        [Header("Visible Attributes")] 
        public PlayerAttribute Health { get; private set; }

        public PlayerAttribute Speed { get; private set; }

        public PlayerAttribute Damage { get; private set; }

        public PlayerAttribute FireDelay { get; private set; }

        public PlayerAttribute Range { get; private set; }

        public PlayerAttribute ShotSpeed { get; private set; }

        public PlayerAttribute Luck { get; private set; }

        [Header("Hidden Attributes")]
        public PlayerAttribute KnockbackStrength { get; private set; }
        public PlayerAttribute ContactDamage { get; private set; }
        [Header("Constraints")]
        private float maxSpeed;
        private float maxHealth;
        private float minValue;
        private float minMultiplier;
        private float maxMultiplier;
        
        [Header("State-Independent Values")]
        public Vector2 MovementDirection { get; set; }
        public float FireDelayBuffer { get; set; }
        public bool IsFiring { get; set; }
        public Vector2 FireDirection { get; set; }

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
            maxHealth = playerInformation.maxHealth;
            minValue = playerInformation.minValue;
            minMultiplier = playerInformation.minMultiplier;
            maxMultiplier = playerInformation.maxMultiplier;
            // ## Visible Attributes
            // ### Health
            Health = new PlayerAttribute(playerInformation.health, 1, minMultiplier, maxMultiplier, 0, playerInformation.maxHealth);
            // ### Speed
            Speed = new PlayerAttribute(playerInformation.speed, playerInformation.speedMultiplier, minMultiplier, maxMultiplier, minValue, playerInformation.maxSpeed);
            // ### Damage
            Damage = new PlayerAttribute(playerInformation.damage, playerInformation.damageMultiplier, minMultiplier, maxMultiplier, minValue, float.MaxValue);
            // ### Fire Delay
            FireDelay = new PlayerAttribute(playerInformation.fireDelay, playerInformation.fireDelayMultiplier,minMultiplier,  maxMultiplier, minValue, 100);
            // ### Range
            Range = new PlayerAttribute(playerInformation.range, playerInformation.rangeMultiplier, minMultiplier,  maxMultiplier, minValue, 10);
            // ### Shot speed
            ShotSpeed = new PlayerAttribute(playerInformation.shotSpeed, 1, minMultiplier, maxMultiplier, minValue, 50);
            // ### Luck
            Luck = new PlayerAttribute(playerInformation.luck, playerInformation.luckMultiplier, minMultiplier,  maxMultiplier, minValue, 50);
            // ## Hidden Attributes
            // ### Knockback strength
            KnockbackStrength = new PlayerAttribute(playerInformation.knockbackStrength, 1, minMultiplier, maxMultiplier, minValue, 10);
            // ### Contact damage
            ContactDamage = new PlayerAttribute(playerInformation.contactDamage, 1, minMultiplier, maxMultiplier, minValue, float.MaxValue);
        }

        private void OnEnable()
        {
            // Subscribe to stat change events
            GameEventManager.Instance.AttributeUpdateEvents.OnDamageMultiplierChange += UpdateDamageMultiplier;
            GameEventManager.Instance.AttributeUpdateEvents.OnDamageChange += UpdateDamage;
            GameEventManager.Instance.AttributeUpdateEvents.OnFireDelayMultiplierChange += UpdateFireDelayMultiplier;
            GameEventManager.Instance.AttributeUpdateEvents.OnFireDelayChange += UpdateFireDelay;
            GameEventManager.Instance.AttributeUpdateEvents.OnSpeedChange += UpdateSpeed;
            GameEventManager.Instance.AttributeUpdateEvents.OnRangeChange += RangeUpdate;
        }

        private void UpdateDamage(float value)
        {
            Damage.UpdateValue(value);
        }
    
        private void UpdateDamageMultiplier(float value)
        {
            Damage.UpdateValue(value);
        }

        private void UpdateFireDelay(float value)
        {
            FireDelay.UpdateValue(value);
        }

        private void UpdateFireDelayMultiplier(float value)
        {
            FireDelay.UpdateMultiplier(value);
        }

        private void UpdateSpeed(float value)
        {
            Speed.UpdateValue(value);
        }
        
        private void UpdateSpeedMultiplier(float value)
        {
            Speed.UpdateMultiplier(value);
        }

        private void RangeUpdate(float value)
        {
            Range.UpdateValue(value);
        }
    }
}
