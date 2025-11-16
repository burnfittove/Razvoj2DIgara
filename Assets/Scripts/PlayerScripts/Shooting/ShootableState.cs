using Events;
using UnityEngine;

namespace PlayerScripts.Shooting
{
    public abstract class ShootableState : State, IShooter
    { 
        protected override void OnEnter()
        {
            GameEventManager.Instance.InputEvents.OnMouseMoved += GetDirection;
            GameEventManager.Instance.InputEvents.OnFirePressed += FirePressed;
        }


        protected override void OnExit()
        {
            GameEventManager.Instance.InputEvents.OnMouseMoved -= GetDirection;
            GameEventManager.Instance.InputEvents.OnFirePressed -= FirePressed;
        }
        private void FirePressed(float value)
        {
            p.IsFiring = value > .1f;
        }

        protected override void OnUpdate()
        {
            if (p.IsFiring) Shoot(p.FireDirection);
        }

        public void Shoot(Vector2 direction)
        {
            // Exit if there is still fire delay
            if (p.FireDelayBuffer > 0) return;

            // Use the BulletPooling Script to Instantiate bullets
            var bullet = BulletPooling.SharedInstance.GetPooledObject();
            if (bullet is not null)
            {
                bullet.transform.position = p.transform.position;
                bullet.Initialize(direction, p.ShotSpeed.Value, p.Damage.Value, p.Range.Value);
                bullet.gameObject.SetActive(true);
            }

            // Set fire delay
            p.FireDelayBuffer = p.FireDelay.Value;
        }

        public void GetDirection(Vector2 cursorWorldPosition)
        {
            p.FireDirection = (Camera.main.ScreenToWorldPoint(cursorWorldPosition) - p.transform.position).normalized;
        }
    }
}