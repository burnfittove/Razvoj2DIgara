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

        public event Action<bool> OnRoomCleared;

        public void RoomCleared(bool createReward)
        {
            OnRoomCleared?.Invoke(createReward);
        }

        public event Action OnChangeRoom;
        public void ChangeRoom()
        {
            OnChangeRoom?.Invoke();
        }
    }
}
