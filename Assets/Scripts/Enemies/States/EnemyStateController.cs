using System;
using Enemies.States.Defaults;
using UnityEngine;

namespace Enemies.States
{
    [RequireComponent(typeof(Enemy))]
    public class EnemyStateController : MonoBehaviour
    {
        // References to other important components
        protected EnemyState currentState;
        protected Enemy enemy;
        // States are public so that one state can reference another
        public readonly EnemyState deathState = new DeathState();
        public readonly EnemyState chaseState = new ChaseState();
        
        protected virtual void Awake()
        {
            // Get components
            enemy = GetComponent<Enemy>();
        }

        // Implement chase state

        protected virtual void Start()
        {
            // Set the default state
            ChangeState(chaseState);
        }

        protected virtual void Update()
        {
            // Run the state's OnUpdate method every frame
            currentState?.OnStateUpdate();
        }
        
        public void ChangeState(EnemyState newState)
        {
            currentState?.OnStateExit();
            currentState = newState;
            currentState.OnStateEnter(this, enemy);
        }
    }
}