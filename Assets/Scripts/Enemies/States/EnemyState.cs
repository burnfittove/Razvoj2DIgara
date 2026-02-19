using UnityEngine;

namespace Enemies.States
{
    public abstract class EnemyState
    {
        protected EnemyStateController enemyStateController;
        protected Enemy enemy;
        
        // Call in EnemyStateController, do not override
        public void OnStateEnter(EnemyStateController sc, Enemy e)
        {
            enemyStateController = sc;
            enemy = e;
            OnEnter();
        }
        // Override in new states
        protected virtual void OnEnter() { }


        // Call in EnemyStateController, do not override
        public void OnStateExit()
        {
            OnExit();
        }
        // Override in new states
        protected virtual void OnExit() { }


        // Call in EnemyStateController, do not override
        public void OnStateUpdate()
        {
            enemy.InvincibilityDuration.UpdateValue(-Time.deltaTime);
            OnUpdate();
        }
        // Override in new states
        protected virtual void OnUpdate() { }
    }
}