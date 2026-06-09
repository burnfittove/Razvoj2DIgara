using Events;
using TMPro;
using UnityEngine;

public class DisplayRoomNumber : MonoBehaviour
{
    private TMP_Text text;
    private readonly string _baseText = "Room: "; 
    
    private void Start()
    {
        TryGetComponent(out text);
        
        GameEventManager.Instance.roomEvents.OnRoomCounterDisplay += UpdateDisplay;
    }

    private void UpdateDisplay(int room)
    {
        text.text = _baseText + room;
    }
}