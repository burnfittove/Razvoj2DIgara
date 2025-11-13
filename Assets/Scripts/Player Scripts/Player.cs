using System;
using Events;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Stats")]
    [Header("Movement")]
    public Vector2 MovementDirection { get; set; }
    public int movementSpeed;
    [Header("Shooting")]
    public float fireDelay;
    public float FireDelayBuffer { get; set; }
    public bool IsFiring { get; set; }
    public float bulletSpeed;
    public float bulletDamage;
    public float bulletDamageMultiplier;
    public float bulletLifetime;

    [Header("Components")]
    [HideInInspector] public Rigidbody2D rb;


    void Awake()
    {
        // Components
        // ### Rigidbody ###
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        // Subsribe to stat change events
        GameEventManager.Instance.statUpdateEvents.OnDamageChange += DamageUpdate;
    }

    private void DamageUpdate(float value)
    {
        // Update the damage
        bulletDamage += ApplyDamageMultiplier( value, bulletDamageMultiplier);
    }
    
    // Apply the damage multiplier on the newly acquired damage
    private float ApplyDamageMultiplier(float dmg, float dmgMult)
    {
        return dmg * dmgMult;
    }
}
