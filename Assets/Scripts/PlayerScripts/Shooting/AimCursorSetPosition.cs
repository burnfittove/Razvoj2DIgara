// using UnityEngine;
//
// /*
// This script moves the position of the player's bullet spawner. This scripts instantiater, ShootingManager, later passes this position to the bullets it fires.
// */
//
// namespace Player_Scripts.Shooting
// {
//     public class AimCursorSetPosition
//     {
//         public AimCursorSetPosition(Player player)
//         {
//             p = player;
//         }
//         private Vector2 position;
//         public Vector2 Position
//         {
//             get => position.normalized;
//             private set => position = value;
//         }
//
//         private Player p;
//
//         public void MoveSpawner(Vector2 worldPosition)
//         {
//             Position = Camera.main.ScreenToWorldPoint(worldPosition) - p.transform.position;
//         }
//     }
// }
