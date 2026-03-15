using Events;
using PlayerScripts.Shooting;
using UnityEngine;

namespace PlayerScripts.States
{
    public class MovementState : ShootableState
    {
        protected override void OnUpdate()
        {
            base.OnUpdate();
            // Move the rigidbody
            Move(p.MovementDirection);
            Rotate(p.MovementDirection);

            if (p.MovementDirection.magnitude <= .2f) sc.ChangeState(sc.idleState);
        }

        protected override void OnExit()
        {
            Rotate(p.MovementDirection);
        }

        private void Move(Vector2 direction)
        {
            p.rb.MovePosition((Vector2)p.transform.position + direction * (PlayerInfo.Instance.Speed.value * Time.fixedDeltaTime));
        }

        private void Rotate(Vector2 direction)
        {
            p.sr.flipX = direction.x < 0;
        }
    }
}
