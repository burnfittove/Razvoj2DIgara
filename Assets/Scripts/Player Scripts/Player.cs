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
    public float fireDelayMultiplier = 1;
    public bool IsFiring { get; set; }
    public float bulletSpeed;
    public float bulletDamage;
    public float bulletDamageMultiplier = 1;
    public float bulletLifetime;

    [Header("Components")]
    [HideInInspector] public Rigidbody2D rb;


    void Awake()
    {
        // Components
        // ### Rigidbody ###
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        // Subscribe to stat change events
        GameEventManager.Instance.statUpdateEvents.OnDamageChange += DamageUpdate;
        GameEventManager.Instance.statUpdateEvents.OnDamageMultiplierChange += DamageMultiplierUpdate;
        GameEventManager.Instance.statUpdateEvents.OnFireDelayChange += FireDelayUpdate;
        GameEventManager.Instance.statUpdateEvents.OnFireDelayMultiplierChange += FireDelayMultiplierUpdate;
    }

    private void DamageUpdate(float value)
    {
        // Update the damage
        ApplyDamageMultiplier( value, bulletDamageMultiplier);
    }
    
    private void DamageMultiplierUpdate(float value)
    {
        bulletDamageMultiplier += value;
        if (bulletDamageMultiplier <= 0) fireDelayMultiplier = .2f;
        ApplyDamageMultiplier(bulletDamage, bulletDamageMultiplier);
    }
    
    // Apply the damage multiplier on the newly acquired damage
    private void ApplyDamageMultiplier(float dmg, float dmgMult)
    {
        bulletDamage =  dmg * dmgMult;
    }

    private void FireDelayUpdate(float value)
    {
        ApplyDelayMultiplier(value, fireDelayMultiplier);
        if (fireDelay <= 0) fireDelay = .2f;
        FireDelayBuffer = fireDelay;
    }

    private void FireDelayMultiplierUpdate(float value)
    {
        fireDelayMultiplier += value;
        if (fireDelayMultiplier <= 0) fireDelayMultiplier = .2f;
        ApplyDelayMultiplier(fireDelay, fireDelayMultiplier);
    }

    private void ApplyDelayMultiplier(float dly, float dlyMult)
    {
        fireDelay = dly * dlyMult;
    }
}
