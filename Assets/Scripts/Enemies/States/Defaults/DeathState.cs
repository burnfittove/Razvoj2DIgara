using Events;
using UnityEngine;
using UnityEngine.Rendering.Universal;

namespace Enemies.States.Defaults
{
    public class DeathState : EnemyState
    {
        protected override void OnEnter()
        {
            // Play sound
            GameEventManager.Instance.audioEvents.PlaySoundWithRandomPitch(enemy.deathSound);
            
            // Disable the navmesh agent
            // enemy.navMeshAgent.isStopped = true;
            enemy.navMeshAgent.enabled = false;
            
            // Disable the animator
            enemy.animator.enabled = false;
            // Disable lights
            enemy.TryGetComponent(out Light2D light);
            if (light) light.enabled = false;

            // Dim the enemy's color and rotate the sprite
            enemy.sr.color = new Color(0.4f, 0.4f, 0.4f, 0.7f);
            enemy.sr.transform.rotation = Quaternion.Euler(0, enemy.sr.transform.rotation.y, 90);
            
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