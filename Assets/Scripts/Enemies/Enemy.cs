using Currencies.Souls;
using Events;
using PlayerScripts;
using UnityEngine;
using UnityEngine.AI;
using Attribute = PlayerScripts.Attribute;

namespace Enemies
{
    public abstract class Enemy: MonoBehaviour, IDamageable
    {
        // Attributes
        public EnemyInformationSO enemyInfo;
        protected Attribute Health;
        protected Attribute Speed;
        protected Attribute Damage;
        protected Attribute FireDelay;
        protected Attribute Range;
        protected Attribute ShotSpeed;
        protected Attribute ContactDamage;
        private Color startColor;
        private const int baseSoulSpawnChance = 100;
        [SerializeField] protected GameObject soulPrefab;
        protected bool isAlive = true; // TODO: Make a state machine so that you don't need variables like this to determine the state of an enemy. Make it simple, don't overcomplicate!
        // Other attributes
        protected bool isInvisible;
        // Components
        protected Rigidbody2D rb;
        protected Collider2D cc;
        protected SpriteRenderer sr;
        protected NavMeshAgent navMeshAgent;
        protected Player player;
        
        protected virtual void Awake()
        {
            rb = GetComponent<Rigidbody2D>();
            sr = GetComponentInChildren<SpriteRenderer>();
            cc = GetComponent<Collider2D>();
            navMeshAgent = GetComponent<NavMeshAgent>();
            player = GameObject.FindWithTag("Player").GetComponent<Player>();
            startColor = sr.color;
            
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
            
            if (isInvisible) sr.enabled = false;
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

        public void TakeDamage(float damage)
        {
            Health.UpdateValue(-damage);
        }

        protected virtual void OnDeath()
        {
            isAlive = false;
            sr.color = startColor / 2;
            cc.enabled = false;
            navMeshAgent.enabled = false;
            GameEventManager.Instance.roomEvents.OnEnemyDeath();
            CreateSoul();
        }

        private void CreateSoul()
        {
            // Get a chance from 0 to 100
            var chance = Random.Range(0, baseSoulSpawnChance + player.Luck.Value / 1.1f);
            // If the chance is greater than the player's luck, do nothing
            if (chance > player.Luck.Value) return;
            // If the soulPrefab is unassigned, do nothing
            if (!soulPrefab)
            {
                Debug.LogWarning($"{this} has unassigned soulPrefab");
                return;
            }
            // Create soul otherwise
            Instantiate(soulPrefab, transform.position, transform.rotation);
        }

        protected virtual void Update()
        {
            if (!isAlive) return;
            if (Health.Value <= 0) OnDeath();
            if (enemyInfo.chasePlayer) ChasePlayer();
        }

        protected virtual void ChasePlayer()
        {
            if (navMeshAgent.enabled) navMeshAgent.SetDestination(player.transform.position);
        }
    }
}
