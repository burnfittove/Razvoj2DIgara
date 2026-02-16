using System;
using Currencies.Souls;
using Events;
using PlayerScripts;
using UnityEngine;
using UnityEngine.AI;
using Attribute = PlayerScripts.Attribute;
using Random = UnityEngine.Random;

namespace Enemies
{
    public abstract class Enemy: MonoBehaviour, IDamageable
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
        [SerializeField] protected GameObject soulPrefab;
        // Components
        [HideInInspector] public Collider2D cc;
        [HideInInspector] public SpriteRenderer sr;
        [HideInInspector] public NavMeshAgent navMeshAgent;
        protected Transform player;
        
        protected virtual void Awake()
        {
            // Get component references
            sr = GetComponentInChildren<SpriteRenderer>();
            cc = GetComponent<Collider2D>();
            navMeshAgent = GetComponent<NavMeshAgent>();
            if (!player) player = GameObject.FindWithTag("Player").transform;
            
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
            Range = new Attribute(enemyInfo.range,  1, 1, 1, 0, enemyInfo.shotSpeed);
            // ## Shot Speed
            ShotSpeed = new Attribute(enemyInfo.shotSpeed, 1, 1, 1, 0, enemyInfo.shotSpeed);
            // ## Contact Damage
            ContactDamage = new Attribute(enemyInfo.contactDamage, 1, 1, 1, 0, enemyInfo.contactDamage);
        }

        protected virtual void Start()
        {
            InitializeNavMeshValues();
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
            // Get a chance from 0 to 100
            var chance = Random.Range(0, enemyInfo.baseMaxSoulSpawnChance + PlayerInfo.Instance.Luck.Value / 1.1f);
            // If the chance is greater than the player's luck, do nothing
            if (chance > PlayerInfo.Instance.Luck.Value) return;
            // If the soulPrefab is unassigned, do nothing
            if (!soulPrefab)
            {
                Debug.LogWarning($"{this} has unassigned soulPrefab");
                return;
            }
            // Create soul otherwise
            Instantiate(soulPrefab, transform.position, transform.rotation);
        }

        public void ChasePlayer()
        {
            if (navMeshAgent.enabled) navMeshAgent.SetDestination(player.transform.position);
        }
        
        public void TakeDamage(float damage)
        {
            Health.UpdateValue(-damage);
        }

        private void OnCollisionStay2D(Collision2D other)
        {
            // Damage the player
            if (other.gameObject.CompareTag("Player") && other.gameObject.TryGetComponent<IDamageable>(out var damageable)) damageable.TakeDamage(ContactDamage.Value);
        }
    }
}
