using UnityEngine;

namespace Events
{
    public class GameEventManager : MonoBehaviour
    {
        // Singleton
        public static GameEventManager Instance { get; private set; }

        public InputEvents inputEvents;
        public AttributeUpdateEvents attributeUpdateEvents;
        public ItemEvents itemEvents;
        public PickupEvents pickupEvents;
        public RoomEvents roomEvents;
        public MainMenuEvents mainMenuEvents;

        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Debug.LogError("Multiple instances of GameEventManager detected!");
            }
            Instance = this;

            // Initialize events
            inputEvents = new InputEvents();
            attributeUpdateEvents = new AttributeUpdateEvents();
            itemEvents = new ItemEvents();
            pickupEvents = new PickupEvents();
            roomEvents = new RoomEvents();
            mainMenuEvents = new MainMenuEvents();
        }
    }
}
