using UnityEngine;

namespace Events
{
    public class GameEventManager : MonoBehaviour
    {
        // Singleton
        public static GameEventManager Instance { get; private set; }

        public InputEvents inputEvents;
        public StatUpdateEvents statUpdateEvents;

        void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Debug.LogError("Multiple instances of GameEventManager detected!");
            }
            Instance = this;

            // Initialize events
            inputEvents = new InputEvents();
            statUpdateEvents = new StatUpdateEvents();
        }
    }
}
