using UnityEngine;

public class AimCursorSetPosition
{
    public AimCursorSetPosition(Player player, ShootingManager shootingManager)
    {
        p = player;
        sh = shootingManager;
    }
    public Vector2 Position { get; private set; }
    private Player p;
    private ShootingManager sh;

    public void MoveSpawner(Vector2 worldPosition)
    {
        Position = Vector3.Normalize(Camera.main.ScreenToWorldPoint(worldPosition) - p.transform.position);
    }

    public void UpdatePosition()
    {
        sh.transform.position = Position + (Vector2)p.transform.position;
    }
}
