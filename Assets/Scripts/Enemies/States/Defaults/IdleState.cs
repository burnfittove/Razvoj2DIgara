namespace Enemies.States.Defaults
{
    public class IdleState : EnemyState
    {
        protected override void OnEnter()
        {
            enemy.navMeshAgent.isStopped = true;
        }

        protected override void OnUpdate()
        {
            // Go from any state directly to the death state if the enemy's health is bellow zero
            if (enemy.Health.value > 0) return; 
            enemyStateController.ChangeState(enemyStateController.deathState);
        }
    }
}