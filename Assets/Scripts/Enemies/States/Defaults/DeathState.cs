using Events;
using UnityEngine;

namespace Enemies.States.Defaults
{
    public class DeathState : EnemyState
    {
        protected override void OnEnter()
        {
            // Disable the navmesh agent
            // enemy.navMeshAgent.isStopped = true;
            enemy.navMeshAgent.enabled = false;
            
            // Dim the enemy's color and rotate the sprite
            enemy.sr.color = new Color(0.5f, 0.5f, 0.5f, 0.6f);
            enemy.transform.rotation = Quaternion.Euler(0f, 0f, 90f);
            
            // Disable collider
            enemy.cc.enabled = false;
            
            // Invoke the enemy death event
            GameEventManager.Instance.roomEvents.EnemyDeath();
            
            // Create a soul
            enemy.CreateSoul();
            
            // Create money
            enemy.CreateMoney();
            
        }
    }
}