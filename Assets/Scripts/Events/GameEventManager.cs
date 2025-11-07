using UnityEngine;

public class GameEventManager : MonoBehaviour
{
    public static GameEventManager instance { get; private set; }

    public InputEvents inputEvents;

    void Awake()
    {
        if (instance != null && instance != this)
        {
            Debug.LogError("Multiple instances of GameEventManager detected!");
        }
        instance = this;

        // Initialize events
        inputEvents = new InputEvents();
    }
}
