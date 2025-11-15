using Player_Scripts.Shooting;
using UnityEngine;

public class IdleState : State
{

    protected override void OnUpdate()
    {
        // Transition to Movement State
        if (p.MovementDirection != Vector2.zero) sc.ChangeState(sc.movementState);
    }
    
    
}
