using System;
using Enemies.States;
using Enemies.States.Defaults;
using UnityEngine;

namespace Prefabs.Enemies.States
{
    public class RoamerEnemyStateController : EnemyStateController
    {
        // Implement chase state
        [HideInInspector] public readonly EnemyState chaseState = new ChaseState();
        
        protected override void Start()
        {
            ChangeState(chaseState);
        }
    }
}
