using Enemies.States.Defaults;
using UnityEngine;

namespace Enemies.States
{
    [RequireComponent(typeof(Enemy))]
    public class ShooterEnemyStateController : EnemyStateController
    {
        // Implement states
        public readonly EnemyState shootState = new ShootState();

        private RaycastHit2D[] hits;
        
        protected override void Start()
        {
            ChangeState(chaseState);
        }

        protected override void Update()
        {
            base.Update();
            
            // Decrease the fireDelayBuffer
            enemy.fireDelayBuffer -= Time.deltaTime * 10;
            
            // Check if the player is within range
            hits = Physics2D.CircleCastAll(transform.position, enemy.enemyInfo.sightRange, Vector2.zero);
            // If the enemy can't see the player, set the state to ChaseState (only once). If they can, set state to shootState (only once)
            foreach (var hit in hits)
            {
                // Exit if the enemy is dead
                if (currentState == deathState) return;
                
                if (!hit.collider.CompareTag("Player"))
                {
                    if (currentState == chaseState) continue;
                    ChangeState(chaseState);
                }

                if (currentState == shootState) continue;
                ChangeState(shootState);
            }
        }
    }
}