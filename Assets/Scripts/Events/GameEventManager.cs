using UnityEngine;

namespace Events
{
    public class GameEventManager : MonoBehaviour
    {
        // Singleton
        public static GameEventManager Instance { get; private set; }

        public InputEvents InputEvents;
        public AttributeUpdateEvents AttributeUpdateEvents;
        public ItemPickupEvents ItemPickupEvents;

        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Debug.LogError("Multiple instances of GameEventManager detected!");
            }
            Instance = this;

            // Initialize events
            InputEvents = new InputEvents();
            AttributeUpdateEvents = new AttributeUpdateEvents();
            ItemPickupEvents = new ItemPickupEvents();
        }
    }
}
