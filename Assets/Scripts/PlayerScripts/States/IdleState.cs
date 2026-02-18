using PlayerScripts.Shooting;
using UnityEngine;

namespace PlayerScripts.States
{
    public class IdleState : ShootableState
    {
        protected override void OnUpdate()
        {
            base.OnUpdate();
            // Transition to Movement State
            if (p.MovementDirection != Vector2.zero) sc.ChangeState(sc.movementState);
        }
    }
}
