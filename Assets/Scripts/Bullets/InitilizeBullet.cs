using Unity.Mathematics;
using UnityEngine;

public class InitilizeBullet : MonoBehaviour
{
    private float damage;
    private float speed;
    private float range;
    private Vector2 direction;
    private Rigidbody2D rb;
    
    public InitilizeBullet(float damage, float speed, float range, Vector2 direction)
    {
        this.damage = 3;
        this.speed = 2;
        this.range = 3;
        this.direction = Vector2.one;
        
        SetScale(this.damage);
    }

    private void SetScale(float dmg)
    {
        transform.localScale = Vector3.one * (math.log(dmg) * 8 + 5);
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = direction * speed;
    }

    private void Update()
    {
        range -= Time.deltaTime;
        
        if (range <= 0) Destroy(gameObject);
    }
}
