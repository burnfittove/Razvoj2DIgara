using Events;
using UnityEngine;
using UnityEngine.InputSystem;

namespace PlayerScripts.Shooting
{
    public abstract class ShootableState : State, IShooter
    { 
        protected override void OnEnter()
        {
            GameEventManager.Instance.inputEvents.OnMouseMoved += GetDirection;
            GameEventManager.Instance.inputEvents.OnFirePressed += FirePressed;
        }


        protected override void OnExit()
        {
            GameEventManager.Instance.inputEvents.OnMouseMoved -= GetDirection;
            GameEventManager.Instance.inputEvents.OnFirePressed -= FirePressed;
        }
        private void FirePressed(InputAction.CallbackContext value)
        {
            p.IsFiring = value.ReadValue<float>() > .1f;
        }

        protected override void OnUpdate()
        {
            if (p.IsFiring) Shoot(p.FireDirection);
        }

        public void Shoot(Vector2 direction)
        {
            // Exit if there is still fire delay
            if (p.FireDelayBuffer > 0) return;

            // Use the PlayerBulletPooling Script to Instantiate bullets
            var bullet = PlayerBulletPooling.Instance.GetPooledObject();
            if (bullet is not null)
            {
                bullet.transform.position = p.transform.position;
                bullet.Initialize(direction, PlayerInfo.Instance.ShotSpeed.value, PlayerInfo.Instance.Damage.value, PlayerInfo.Instance.Range.value);
                bullet.gameObject.SetActive(true);
            }

            // Set fire delay
            p.FireDelayBuffer = PlayerInfo.Instance.FireDelay.value;
        }

        public void GetDirection(InputAction.CallbackContext cursorWorldPosition)
        {
            if (Camera.main == null) return; 
            p.FireDirection = (Camera.main.ScreenToWorldPoint(cursorWorldPosition.ReadValue<Vector2>()) - p.transform.position).normalized;
        }
    }
}