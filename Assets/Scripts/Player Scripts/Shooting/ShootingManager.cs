using Unity.VisualScripting;
using UnityEngine;

public class ShootingManager : MonoBehaviour
{
    private Player p;
    private IShooter shooter;
    private AimCursorSetPosition aimCursor;

    void Awake()
    {
        p = GetComponentInParent<Player>();

        shooter = GetComponentInParent<PlayerShooter>();
        aimCursor = new AimCursorSetPosition(p, this);
    }

    void OnEnable()
    {
        GameEventManager.instance.inputEvents.OnFirePressed += FirePressed;
        GameEventManager.instance.inputEvents.OnMouseMoved += aimCursor.MoveSpawner;
    }

    void OnDisable()
    {
        GameEventManager.instance.inputEvents.OnFirePressed -= FirePressed;
        GameEventManager.instance.inputEvents.OnMouseMoved -= aimCursor.MoveSpawner;
    }

    void Update()
    {
        // Fire if the player is pressing the Fire button
        if (p.IsFiring) shooter.Shoot(aimCursor.Position);

        // Constantly decrease fire buffer
        DecreaseFireBuffer();
    }

    void LateUpdate()
    {
        aimCursor.UpdatePosition();
    }

    private void DecreaseFireBuffer()
    {
        p.FireDelayBuffer -= Time.deltaTime;
    }

    private void FirePressed(float isPressed)
    {
        p.IsFiring = isPressed > .1f;
    }
}