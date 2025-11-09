using UnityEngine;

public class ShootingManager : MonoBehaviour
{
    private Player p;

    void Awake()
    {
        p = GetComponent<Player>();
    }

    void OnEnable()
    {
        GameEventManager.instance.inputEvents.OnFirePressed += FirePressed;
    }

    void OnDisable()
    {
        GameEventManager.instance.inputEvents.OnFirePressed -= FirePressed;
    }

    void Update()
    {
        // Fire if the player is pressing the Fire button
        if (p.IsFiring) FireBullet();
        
        // Constantly decrease fire buffer
        DecreaseFireBuffer();
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
        Debug.Log($"Fire ! ! !");
        
        // Set fire delay
        p.FireDelayBuffer = p.fireDelay;
    }

    private void FirePressed(float isPressed)
    {
        p.IsFiring = isPressed > .1f;
    }
}