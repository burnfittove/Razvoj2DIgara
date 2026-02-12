using System;
using UnityEngine;

namespace Events
{
    public sealed class RoomEvents
    {
        public event Action EnemyDeath;

        public void OnEnemyDeath()
        {
            EnemyDeath?.Invoke();
        }
    }
}
