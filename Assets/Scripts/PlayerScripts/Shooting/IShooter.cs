using Events;
using UnityEngine;

public interface IShooter
{
    public void Shoot(Vector2 direction);
    public void GetDirection(Vector2 cursorWorldPosition);
    public void DecreaseDelay(ref float delay)
    {
        delay -= Time.deltaTime * 10;
    }
}
