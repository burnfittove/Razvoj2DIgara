using System;
using UnityEngine;

public class MovementState : State
{
    protected override void OnUpdate()
    {
        // Move the rigidbody
        Move(p.MovementDirection);

        if (p.MovementDirection.magnitude <= .2f) sc.ChangeState(sc.idleState);
    }

    private void Move(Vector2 direction)
    {
        p.rb.linearVelocity = direction * (p.movementSpeed * Time.fixedDeltaTime);
    }
}
