namespace Enemies.Close_range.Roamer
{
    public class Roamer : Enemy
    {
        protected override void OnUpdate()
        {
            if (navMeshAgent.enabled) navMeshAgent.SetDestination(player.transform.position);
        }
    }
}
