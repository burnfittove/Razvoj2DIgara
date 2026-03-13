using System;
using Currencies.Money;
using Currencies.Souls;
using Events;
using Managers;
using PlayerScripts;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using Attribute = PlayerScripts.Attribute;
using Random = UnityEngine.Random;

namespace Enemies
{
    public class Enemy: MonoBehaviour, IDamageable
    {
        // Attributes
        public EnemyInformationSo enemyInfo;
        public Attribute Health { get; private set; }
        public Attribute Speed { get; private set; }
        public Attribute Damage { get; private set; }
        public Attribute FireDelay { get; private set; }
        public Attribute Range { get; private set; }
        public Attribute ShotSpeed { get; private set; }
        public Attribute ContactDamage { get; private set; }
        public Attribute InvincibilityDuration { get; private set; }
        // Shooting-related field(s)
        [HideInInspector] public float fireDelayBuffer;
        // Components
        [HideInInspector] public Collider2D cc;
        [HideInInspector] public SpriteRenderer sr;
        [HideInInspector] public NavMeshAgent navMeshAgent;
        [HideInInspector] public Transform player;
        [HideInInspector] public Animator animator;
        // Bool that determines whether the enemy will spawn a soul when they die
        private GameObject soulPrefab;
        // Bool that determines whether the enemy will spawn money when they die and how many instances
        private GameObject[] moneyObjects = new GameObject[4];
        [SerializeField] private int nickelChance = 30;
        [SerializeField] private int dimeChance = 50;
        [SerializeField] private int quarterChance = 100;
        
        protected virtual void Awake()
        {
            // Get component references
            sr = GetComponentInChildren<SpriteRenderer>();
            cc = GetComponent<Collider2D>();
            navMeshAgent = GetComponent<NavMeshAgent>();
            player = GameObject.FindWithTag("Player")?.transform;
            if (!player) gameObject.SetActive(false);
            animator = GetComponent<Animator>();
            
            // # Attributes
            // ## Health
            Health = new Attribute(enemyInfo.health, 1, 1, 1, 0, enemyInfo.health);
            // ## Speed
            Speed = new Attribute(enemyInfo.speed, 1, 1, 1, 1, enemyInfo.speed);
            // ## Damage
            Damage = new Attribute(enemyInfo.damage, 1, 1, 1, 0, enemyInfo.damage);
            // ## Fire Delay
            FireDelay = new Attribute(enemyInfo.fireDelay, 1, 1, 1, 0, enemyInfo.fireDelay);
            // ## Range
            Range = new Attribute(enemyInfo.range,  1, 1, 1, 0, enemyInfo.range);
            // ## Shot Speed
            ShotSpeed = new Attribute(enemyInfo.shotSpeed, 1, 1, 1, 0, enemyInfo.shotSpeed);
            // ## Contact Damage
            ContactDamage = new Attribute(enemyInfo.contactDamage, 1, 1, 1, 0, enemyInfo.contactDamage);
            // ## Invincibility
            InvincibilityDuration = new Attribute(enemyInfo.invincibilityDuration, 1, 1, 1, 0, enemyInfo.invincibilityDuration);
        }

        protected virtual void Start()
        {
            InitializeNavMeshValues();
            CalculateChance2SpawnSoul();
            CalculateChance2SpawnMoney();
        }

        protected virtual void InitializeNavMeshValues()
        {
            navMeshAgent.updateRotation = false;
            navMeshAgent.updateUpAxis = false;
            navMeshAgent.speed = enemyInfo.speed;
            navMeshAgent.acceleration = enemyInfo.acceleration;
            navMeshAgent.angularSpeed = enemyInfo.speed * 20;
        }

        public void CreateSoul()
        {
            // If the enemy shouldn't spawn a soul, return
            if (!soulPrefab) return;
            // Create soul otherwise
            RevealReward(soulPrefab, transform.position);
        }

        public void CreateMoney()
        {
            // If the enemy shouldn't spawn money, return
            if (moneyObjects == null) return;
            // Create each money object otherwise
            foreach (var moneyObject in moneyObjects)
            {
                if (!moneyObject) break;
                RevealReward(moneyObject, (Vector2)transform.position + new Vector2(Random.Range(0, .3f), Random.Range(0, .3f)));
            }
        }

        public void ChasePlayer()
        {
            if (navMeshAgent.enabled) navMeshAgent.SetDestination(player.transform.position);
        }
        
        public void TakeDamage(float damage)
        {
            Health.UpdateValue(-damage);
        }

        public void TakeContactDamage(float damage)
        {
            // If the enemy has recently been damaged, return
            if (InvincibilityDuration.value > 0) return;
            
            // Take contact damage
            Health.UpdateValue(-damage);
            
            // Set invincibility timer
            InvincibilityDuration.UpdateValue(enemyInfo.invincibilityDuration);
        }

        private void OnCollisionStay2D(Collision2D other)
        {
            // Damage the player
            if (other.gameObject.CompareTag("Player") && other.gameObject.TryGetComponent<IDamageable>(out var damageable)) damageable.TakeContactDamage(ContactDamage.value);
        }

        private void CalculateChance2SpawnSoul()
        {
            // Get a chance from 0 to baseMaxSoulSpawnChance
            var chance = Random.Range(0, enemyInfo.baseMaxSoulSpawnChance + PlayerInfo.Instance.Luck.value / 1.5f);
            // If the chance is greater than the player's luck, do nothing
            if (chance > PlayerInfo.Instance.Luck.value) return;
            // Otherwise, create a soul to spawn
            soulPrefab = RewardManager.Instance.GetRewardSoul();
        }
        
        private void CalculateChance2SpawnMoney()
        {
            // Get a chance from 0 to baseMaxMoneySpawnChance
            var chance = Random.Range(0, enemyInfo.baseMaxMoneySpawnChance + PlayerInfo.Instance.Luck.value / 1.8f);
            // If the chance is greater than the player's luck, do nothing
            if (chance > PlayerInfo.Instance.Luck.value) return;
            // Otherwise, get a random number from 1-4 (the amount of money instances to spawn) and decide which type of money the player will be rewarded
            var amount = Random.Range(1, 5);
            for (var i = 0; i < amount; i++)
            {
                // Chance for quarter
                chance = Random.Range(0, quarterChance + PlayerInfo.Instance.Luck.value / 1.1f);
                if (chance <= PlayerInfo.Instance.Luck.value)
                {
                    moneyObjects[i] = RewardManager.Instance.GetRewardMoney(MoneyValue.Quarter);
                    continue;
                }
                
                // Chance for dime
                chance = Random.Range(0, dimeChance + PlayerInfo.Instance.Luck.value / 1.1f);
                if (chance <= PlayerInfo.Instance.Luck.value)
                {
                    moneyObjects[i] = RewardManager.Instance.GetRewardMoney(MoneyValue.Dime);
                    continue;
                }
                
                // Chance for nickel
                chance = Random.Range(0, nickelChance + PlayerInfo.Instance.Luck.value / 1.1f);
                if (chance <= PlayerInfo.Instance.Luck.value)
                {
                    moneyObjects[i] = RewardManager.Instance.GetRewardMoney(MoneyValue.Nickel);
                    continue;
                }
                
                // If all else fails, reward a penny
                moneyObjects[i] = RewardManager.Instance.GetRewardMoney(MoneyValue.Penny);
            }
        }

        private void RevealReward(GameObject reward, Vector2 position)
        {
            reward.transform.position = position;
            reward.SetActive(true);
        }
    }
}
