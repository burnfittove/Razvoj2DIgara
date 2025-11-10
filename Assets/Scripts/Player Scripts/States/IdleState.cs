using UnityEngine;

public class IdleState : State
{
    /* protected override void OnEnter()
    {
        GameEventManager.instance.inputEvents.OnFirePressed += FirePressed;
    } */

    protected override void OnUpdate()
    {
        // Transition to Movement State
        if (p.MovementDirection != Vector2.zero) sc.ChangeState(sc.movementState);
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
