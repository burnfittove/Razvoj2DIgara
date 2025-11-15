// using Events;
// using Player_Scripts.Shooting;
//
// namespace Player_Scripts.States
// {
//     public class ShootableState : State
//     {
//         protected ShootingManager sh;
//         
//         public ShootableState(ShootingManager shootingManager)
//         {
//             sh = shootingManager;
//         }
//         
//         protected override void OnEnter()
//         {
//             GameEventManager.Instance.inputEvents.OnFirePressed += FirePressed;
//             GameEventManager.Instance.inputEvents.OnMouseMoved += aimCursor.MoveSpawner;
//         }
//         
//         protected void UpdatePosition()
//         {
//             p.cursor.position = aimCursor.Position + (Vector2)p.transform.position;
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
//     }
// }