using System;

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

        public event Action OnChangeRoom;
        public void ChangeRoom()
        {
            OnChangeRoom?.Invoke();
        }
        
        public event Action<int> OnRoomCounterDisplay;
        public void RoomCounterDisplay(int room)
        {
            OnRoomCounterDisplay?.Invoke(room);
        }
    }
}
