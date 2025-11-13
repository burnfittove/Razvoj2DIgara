using Events;
using UnityEngine;

/*
This script combines the functions of PlayerShooter (which pools bullets) and AimCurosrSetPosition (which updates the position in which bullets should travel once fired). It assigns two functions to two GameEventManager events; its FirePressed and AimCursorSetPosition's MoveSpawner.
*/

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
        GameEventManager.Instance.inputEvents.OnFirePressed += FirePressed;
        GameEventManager.Instance.inputEvents.OnMouseMoved += aimCursor.MoveSpawner;
    }

    void OnDisable()
    {
        GameEventManager.Instance.inputEvents.OnFirePressed -= FirePressed;
        GameEventManager.Instance.inputEvents.OnMouseMoved -= aimCursor.MoveSpawner;
    }

    void Update()
    {
        // Fire if the player is pressing the Fire button
        if (p.IsFiring) shooter.Shoot(aimCursor.Position);

        // Constantly decrease fire buffer
        DecreaseFireBuffer();
        
        // Update the cursor position
        UpdatePosition();
    }

    private void UpdatePosition()
    {
        transform.position = aimCursor.Position + (Vector2)p.transform.position;
    }

    private void DecreaseFireBuffer()
    {
        p.FireDelayBuffer -= Time.deltaTime * 10;
    }

    private void FirePressed(float isPressed)
    {
        p.IsFiring = isPressed > .1f;
    }
    
    
}