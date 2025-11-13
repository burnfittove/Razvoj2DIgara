using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Bullet : MonoBehaviour
{
    protected Rigidbody2D rb;
    protected Vector2 moveDirection;
    protected float moveSpeed;
    protected float damage;
    protected float lifetime;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        DecreaseLifetime();
    }

    void FixedUpdate()
    {
        Move();
    }

    public virtual void Initialize(Vector2 dir, float speed, float damage, float lifetime)
    {
        dir.Normalize();
        moveDirection = dir;
        moveSpeed = speed;
        this.damage = damage;
        this.lifetime = lifetime;
    }

    private void Move()
    {
        rb.MovePosition((Vector2)transform.position + moveDirection * (Time.fixedDeltaTime * moveSpeed));
    }

    private void DecreaseLifetime()
    {
        lifetime -= Time.deltaTime * 10;

        if (lifetime <= 0) gameObject.SetActive(false);
    }
}
