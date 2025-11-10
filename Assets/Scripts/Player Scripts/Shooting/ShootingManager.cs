using Unity.Mathematics;
using UnityEngine;

public class ShootingManager : MonoBehaviour
{
    private Player p;
    private Vector2 position;

    void Awake()
    {
        p = GetComponentInParent<Player>();
    }

    void OnEnable()
    {
        GameEventManager.instance.inputEvents.OnFirePressed += FirePressed;
        GameEventManager.instance.inputEvents.OnMouseMoved += MoveSpawner;
    }

    void OnDisable()
    {
        GameEventManager.instance.inputEvents.OnFirePressed -= FirePressed;
        GameEventManager.instance.inputEvents.OnMouseMoved -= MoveSpawner;
    }

    void Update()
    {
        // Fire if the player is pressing the Fire button
        if (p.IsFiring) FireBullet();

        // Constantly decrease fire buffer
        DecreaseFireBuffer();
    }

    void LateUpdate()
    {
        // Update the position
        UpdatePosition();
    }

    private void DecreaseFireBuffer()
    {
        p.FireDelayBuffer -= Time.deltaTime;
    }

    private void FireBullet()
    {
        // Exit if there is still fire delay
        if (p.FireDelayBuffer > 0) return;
        // Exit if the player is not in the movment or idle state

        // Stuff
        Debug.Log($"Fire!!");
        var bulletToInst = Instantiate(p.Bullet);

        // Set fire delay
        p.FireDelayBuffer = p.fireDelay;
    }

    private void FirePressed(float isPressed)
    {
        p.IsFiring = isPressed > .1f;
    }

    void MoveSpawner(Vector2 worldPosition)
    {
        position = Vector3.Normalize(Camera.main.ScreenToWorldPoint(worldPosition) - p.transform.position);
    }

    void UpdatePosition()
    {
        transform.position = position + (Vector2)p.transform.position;
    }
}