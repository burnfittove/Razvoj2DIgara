using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Bullet : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector2 moveDirection;
    private float moveSpeed;
    private float damage;
    private float range;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        rb.MovePosition(moveDirection * moveSpeed);
    }

    void Update()
    {
        range -= Time.deltaTime;

        if (range <= 0) Destroy(gameObject);
    }

    public void Initialize(Vector2 direction, float speed, float damage, float range)
    {
        moveDirection = direction.normalized;
        moveSpeed = speed;
        this.damage = damage;
        this.range = range;
        //SetScaleFromDamage(damage);
    }

    private void SetScaleFromDamage(float damage)
    {
        float scale = math.log(math.pow(damage, 2) * 10) + 5;
        transform.localScale = new Vector3(scale, scale, 1f);
    }
}
