using System;
using Enemies.States;
using Enemies.States.Defaults;
using UnityEngine;

namespace Prefabs.Enemies.Close_range.Roamer.States
{
    public class RoamerEnemyStateController : EnemyStateController
    {
        // Implement chase state
        public readonly EnemyState chaseState = new ChaseState();

        protected override void Start()
        {
            // Set the default state
            ChangeState(chaseState);
        }
    }
}
