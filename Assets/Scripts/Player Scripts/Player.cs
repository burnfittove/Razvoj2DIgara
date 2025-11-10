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
    public float BulletSpeed { get; private set; }
    public float BulletDamage { get; private set; }
    public GameObject Bullet;

    [Header("Components")]
    [HideInInspector] public Rigidbody2D rb;


    void Awake()
    {
        // Components
        // ### Rigidbody ###
        rb = GetComponent<Rigidbody2D>();
    }
}
