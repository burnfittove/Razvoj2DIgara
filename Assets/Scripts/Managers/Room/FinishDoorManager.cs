using Events;
using UnityEngine;

namespace Managers.Room
{
    public class FinishDoorManager : MonoBehaviour
    {
        public Sprite doorOpen;
        public Sprite doorClosed;
        private SpriteRenderer sr;

        private void Awake()
        {
            // Get component references
            sr = GetComponentInChildren<SpriteRenderer>();
            
            // Initialize sprite
            sr.sprite = doorClosed;
            
            // Subscribe to events
            GameEventManager.Instance.roomEvents.OnRoomCleared += OpenDoor;
        }

        private void OpenDoor()
        {
            sr.sprite = doorOpen;
        }
    }
}
