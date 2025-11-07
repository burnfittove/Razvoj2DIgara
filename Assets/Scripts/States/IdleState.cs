using UnityEngine;

public class IdleState : State
{
    protected override void OnEnter()
    {
        GameEventManager.instance.inputEvents.OnFirePressed += FirePressed;
    }

    protected override void OnUpdate()
    {
        // Transition to Movement State
        if (p.MovementDirection != Vector2.zero) sc.ChangeState(sc.movementState);

        if (p.IsFiring) FireBullet();

        DecreaseFireBuffer();
    }

    private void DecreaseFireBuffer()
    {
        p.FireDelayBuffer -= Time.deltaTime;
    }

    private void FireBullet()
    {
        if (p.FireDelayBuffer > 0) return;
        Debug.Log($"Fire pressed in Movement State");
        p.FireDelayBuffer = p.fireDelay;
    }

    protected override void OnExit()
    {
        GameEventManager.instance.inputEvents.OnFirePressed -= FirePressed;
    }

    private void FirePressed(float isPressed)
    {
        p.IsFiring = isPressed > .1f;
    }
}
