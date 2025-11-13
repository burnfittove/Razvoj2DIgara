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
        GameEventManager.Instance.statUpdateEvents.OnSpeedChange += SpeedUpdate;
        GameEventManager.Instance.statUpdateEvents.OnLifetimeChange += LifetimeUpdate;
    }

    private void DamageUpdate(float value)
    {
        // Update the damage
        ApplyDamageMultiplier( value, bulletDamageMultiplier);
    }
    
    private void DamageMultiplierUpdate(float value)
    {
        bulletDamageMultiplier += value;
        if (bulletDamageMultiplier <= .2f) bulletDamageMultiplier = .2f;
        bulletDamage *= bulletDamageMultiplier;
    }
    
    // Apply the damage multiplier on the newly acquired damage
    private void ApplyDamageMultiplier(float dmg, float dmgMult)
    {
        bulletDamage += dmg * dmgMult;
    }

    private void FireDelayUpdate(float value)
    {
        ApplyDelayMultiplier(value, fireDelayMultiplier);
        if (fireDelay <= .2f) fireDelay = .2f;
        FireDelayBuffer = fireDelay;
    }

    private void FireDelayMultiplierUpdate(float value)
    {
        fireDelayMultiplier += value;
        if (fireDelayMultiplier <= .2f) fireDelayMultiplier = .2f;
        fireDelay *= fireDelayMultiplier;
    }

    private void ApplyDelayMultiplier(float dly, float dlyMult)
    {
        fireDelay += dly * dlyMult;
    }

    private void SpeedUpdate(int value)
    {
        if (movementSpeed > 500) movementSpeed = 500;
        else movementSpeed += value;
    }

    private void LifetimeUpdate(float value)
    {
        bulletLifetime += value;
        if (bulletLifetime <= .2f) bulletLifetime = .2f;
    }
}
