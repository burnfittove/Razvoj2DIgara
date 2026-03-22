using PlayerScripts.Shooting;
using UnityEngine;

namespace PlayerScripts.States
{
    public class MovementState : ShootableState
    {
        private static readonly int IsWalking = Animator.StringToHash("isWalking");

        protected override void OnEnter()
        {
            base.OnEnter();
            p.animator.speed = Mathf.Log10(Mathf.Pow(PlayerInfo.Instance.Speed.value + 0.5f, 2)) + 1;
            p.animator.SetBool(IsWalking, true);
        }

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
            base.OnExit();
            p.animator.SetBool(IsWalking, false);
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
