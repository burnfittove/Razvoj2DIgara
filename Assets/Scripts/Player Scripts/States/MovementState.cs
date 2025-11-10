using System;
using UnityEngine;

public class MovementState : State
{
    /* protected override void OnEnter()
    {
        GameEventManager.instance.inputEvents.OnFirePressed += FirePressed;
    } */

    protected override void OnUpdate()
    {
        // Move the rigidbody
        //p.rb.MovePosition(p.rb.position + p.movementDirection * p.movementSpeed * Time.fixedDeltaTime);
        p.rb.linearVelocity = p.MovementDirection * p.movementSpeed * Time.fixedDeltaTime;

        if (p.MovementDirection.magnitude <= .2f) sc.ChangeState(sc.idleState);
    }

    /* protected override void OnExit()
    {
        GameEventManager.instance.inputEvents.OnFirePressed -= FirePressed;
    }

    private void FirePressed(float isPressed)
    {
        p.IsFiring = isPressed > .1f;
    } */
}
