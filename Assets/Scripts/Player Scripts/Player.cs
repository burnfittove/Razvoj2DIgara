using System;
using Events;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Stats")]
    [Header("Movement")]
    public Vector2 MovementDirection { get; set; }
    public int movementSpeed;
    public int maxMovementSpeed;
    [Header("Shooting")]
    public float fireDelay;
    public float FireDelayBuffer { get; set; }
    public float fireDelayMultiplier = 1;
    public bool IsFiring { get; set; }
    public float bulletSpeed;
    public float bulletDamage;
    public float bulletDamageMultiplier = 1;
    public float bulletLifetime;
    public float bulletLifetimeMultiplier = 1;
    private const float MinVal = .2f;
    private const float MinMult = .1f;
    public Transform cursor;

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
        // Exit if the value is 0
        if (value == 0) return;
        // Update the damage
        UpdateStat(ref bulletDamage, value, bulletDamageMultiplier);
        // Check for minVal
        if (bulletDamage <= MinVal) bulletDamage = MinVal;
    }
    
    private void DamageMultiplierUpdate(float value)
    {
        // Exit if the value is 0
        if (value == 0) return;
        // Multiply the current multiplier by the passes value
        bulletDamageMultiplier *= value;
        // Check if the multiplier is smaller than the minimum
        if (bulletDamageMultiplier <= MinMult) bulletDamageMultiplier = MinMult;
        // Apply the damage multiplier
        ApplyMultiplier(ref bulletDamage, bulletDamageMultiplier);
    }
    
    // Apply a multiplier value and update the stat
    private void ApplyMultiplier(ref float stat, float multiplier)
    {
        stat *= multiplier;
    }

    private void UpdateStat(ref float stat, float value, float multiplier)
    {
        stat += value * multiplier;
    }

    private void FireDelayUpdate(float value)
    {
        // Exit if the value is 0
        if (value == 0) return;
        // Update the fire delay
        UpdateStat(ref fireDelay, value, fireDelayMultiplier);
        // Check for minVal
        if (fireDelay <= MinVal) fireDelay = MinVal;
    }

    private void FireDelayMultiplierUpdate(float value)
    {
        // Exit if the value is 0
        if (value == 0) return;
        // Multiply the current multiplier by the passes value
        fireDelayMultiplier *= value;
        // Check if the multiplier is smaller than the minimum
        if (fireDelayMultiplier <= MinMult) fireDelayMultiplier = MinMult;
        // Apply the fire delay multiplier
        ApplyMultiplier(ref fireDelay, fireDelayMultiplier);
    }

    private void SpeedUpdate(int value)
    {
        // Exit if the value is 0
        if (value == 0) return;
        // Check if speed is above maximum
        if (movementSpeed + value > maxMovementSpeed) movementSpeed = maxMovementSpeed;
        else movementSpeed += value;
    }

    private void LifetimeUpdate(float value)
    {
        // Exit if the value is 0
        if (value == 0) return;
        // Increase the bullet lifetime
        UpdateStat(ref bulletLifetime, value, bulletLifetimeMultiplier);
        // Check for minVal
        if (bulletLifetime <= MinVal) bulletLifetime = MinVal;
    }
}
