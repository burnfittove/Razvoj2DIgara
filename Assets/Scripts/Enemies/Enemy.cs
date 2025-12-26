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
            sr.color = new Color(sr.color.r / 3, sr.color.g / 3, sr.color.b / 3);
            cc.enabled = false;
            navMeshAgent.enabled = false;
        }

        protected virtual void Update()
        {
            if (Health.Value <= 0) OnDeath();
            if (enemyInfo.chasePlayer) ChasePlayer();
        }

        protected virtual void ChasePlayer()
        {
            if (navMeshAgent.enabled) navMeshAgent.SetDestination(player.transform.position);
        }
    }
}
