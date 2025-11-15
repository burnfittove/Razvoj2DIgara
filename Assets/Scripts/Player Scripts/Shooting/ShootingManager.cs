// using Events;
// using UnityEngine;
// using UnityEngine.InputSystem.iOS;
//
// /*
// This script combines the functions of PlayerShooter (which pools bullets) and AimCursorSetPosition (which updates the position in which bullets should travel once fired). It assigns two functions to two GameEventManager events; its FirePressed and AimCursorSetPosition's MoveSpawner.
// */
//
// namespace Player_Scripts.Shooting
// {
//     public class ShootingManager
//     {
//         private Player p;
//         protected IShooter shooter;
//         protected AimCursorSetPosition aimCursor;
//         protected Transform cursor;
//
//         public ShootingManager(Transform cursor)
//         {
//             this.cursor = cursor;
//             shooter = new PlayerShooter(p);
//             aimCursor = new AimCursorSetPosition(p);
//         }
//         
//         // private void Awake()
//         // {
//         //     p = GetComponentInParent<Player>();
//         //
//         //     shooter = new PlayerShooter(p);
//         //     aimCursor = new AimCursorSetPosition(p);
//         // }
//         //
//         // private void OnEnable()
//         // {
//         //     GameEventManager.Instance.inputEvents.OnFirePressed += FirePressed;
//         //     GameEventManager.Instance.inputEvents.OnMouseMoved += aimCursor.MoveSpawner;
//         // }
//         //
//         // private void OnDisable()
//         // {
//         //     GameEventManager.Instance.inputEvents.OnFirePressed -= FirePressed;
//         //     GameEventManager.Instance.inputEvents.OnMouseMoved -= aimCursor.MoveSpawner;
//         // }
//         //
//         // private void Update()
//         // {
//         //     // Fire if the player is pressing the Fire button
//         //     if (p.IsFiring) shooter.Shoot(aimCursor.Position);
//         //
//         //     // Constantly decrease fire buffer
//         //     DecreaseFireBuffer();
//         //
//         //     // Update the cursor position
//         //     UpdatePosition();
//         // }
//
//         protected void UpdatePosition()
//         {
//             cursor.position = aimCursor.Position + (Vector2)p.transform.position;
//         }
//
//         protected void DecreaseFireBuffer()
//         {
//             p.FireDelayBuffer -= Time.deltaTime * 10;
//         }
//
//         protected void FirePressed(float isPressed)
//         {
//             p.IsFiring = isPressed > .1f;
//         }
//         
//         public void MoveSpawner(Vector2 worldPosition)
//         {
//             Position = Camera.main.ScreenToWorldPoint(worldPosition) - p.transform.position;
//         }
//     }
// }