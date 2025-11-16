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

            if (p.MovementDirection.magnitude <= .2f) sc.ChangeState(sc.IdleState);
        }

        private void Move(Vector2 direction)
        {
            p.rb.MovePosition((Vector2)p.transform.position + direction * (p.Speed.Value * Time.fixedDeltaTime));
        }
    }
}
