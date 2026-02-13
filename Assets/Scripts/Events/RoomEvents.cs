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

        public event Action RoomCleared;

        public void OnRoomCleared()
        {
            RoomCleared?.Invoke();
        }
    }
}
