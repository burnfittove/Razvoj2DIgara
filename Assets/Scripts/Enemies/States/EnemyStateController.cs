using System;
using Enemies.States.Defaults;
using UnityEngine;

namespace Enemies.States
{
    [RequireComponent(typeof(Enemy))]
    public abstract class EnemyStateController : MonoBehaviour
    {
        // References to other important components
        protected EnemyState currentState;
        protected Enemy enemy;
        // States are public so that one state can reference another
        [HideInInspector] public readonly EnemyState deathState = new DeathState();

        protected virtual void Awake()
        {
            // Get components
            enemy = GetComponent<Enemy>();
        }

        /// <summary>
        /// Start method of every unique enemy state controller needs to implement a default state (i.e. chase or idle)
        /// </summary>
        protected abstract void Start();

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