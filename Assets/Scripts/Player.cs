using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Movement")]
    public Vector2 MovementDirection { get; set; }
    public int movementSpeed;
    [Header("Shooting")]
    public float fireDelay;
    public float FireDelayBuffer { get; set; }
    public bool IsFiring { get; set; }

    [Header("Components")]
    [HideInInspector] public Rigidbody2D rb;


    void Awake()
    {
        // Components
        // ### Rigidbody ###
        rb = GetComponent<Rigidbody2D>();
    }
}
