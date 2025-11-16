// using UnityEngine;
//
// /*
// This script pools bullets to avoid potential performance dips due to instantiating during gameplay.
// */
//
// namespace Player_Scripts.Shooting
// {
//     public class PlayerShooter : IShooter
//     {
//         private Player p;
//
//         public PlayerShooter(Player player)
//         {
//             p = player;
//         }
//
//         public void Shoot(Vector2 direction)
//         {
//             // Exit if there is still fire delay
//             if (p.FireDelayBuffer > 0) return;
//
//             // Use the BulletPooling Script to Instantiate bullets
//             var bullet = BulletPooling.SharedInstance.GetPooledObject();
//             if (bullet is not null)
//             {
//                 bullet.transform.position = p.transform.position;
//                 bullet.Initialize(direction, p.bulletSpeed, p.bulletDamage, p.bulletLifetime);
//                 bullet.gameObject.SetActive(true);
//             }
//
//             // Set fire delay
//             p.FireDelayBuffer = p.fireDelay;
//         }
//
//         public void DecreaseDelay()
//         {
//             
//         }
//     }
// }
