using System;
using UnityEngine;

namespace Enemies.States.Defaults
{
    public class ShootState : ChaseState
    {
        protected override void OnUpdate()
        {
            base.OnUpdate();
            
            // Shoot bullets when the player is in range of the trigger
            Shoot();
        }

        private void Shoot()
        {
            // Exit if there is still fire delay
            if (enemy.fireDelayBuffer > 0) return;
            
            // Use the EnemyBulletPooling Script to Instantiate bullets
            var bullet = EnemyBulletPooling.Instance.GetPooledObject();
            if (bullet is not null)
            {
                bullet.transform.position = enemy.transform.position;
                bullet.Initialize(GetDirection2Player(), enemy.enemyInfo.shotSpeed, enemy.enemyInfo.damage, enemy.enemyInfo.range);
                bullet.gameObject.SetActive(true);
            }

            // Set fire delay
            enemy.fireDelayBuffer = enemy.enemyInfo.fireDelay;
        }

        private Vector2 GetDirection2Player()
        {
            return (enemy.player.position - enemy.transform.position).normalized;
        }
    }
}
