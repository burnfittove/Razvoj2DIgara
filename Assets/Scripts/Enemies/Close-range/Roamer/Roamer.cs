using Enemies;
using UnityEngine;

public class Roamer : Enemy
{
    private void Update()
    {
        //Move(Vector2.left);
    }

    protected override void Move(Vector2 direction)
    {
        rb.linearVelocity = direction * (enemyInfo.speed * Time.fixedDeltaTime);
    }
}
