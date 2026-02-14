using System;
using UnityEngine;

namespace Events
{
    public sealed class RoomEvents
    {
        public event Action OnEnemyDeath;

        public void EnemyDeath()
        {
            OnEnemyDeath?.Invoke();
        }

        public event Action OnRoomCleared;

        public void RoomCleared()
        {
            OnRoomCleared?.Invoke();
        }
    }
}
