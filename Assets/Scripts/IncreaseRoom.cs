using Managers;
using UnityEngine;

public class IncreaseRoom : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;
        RoomManager.Instance.DebugTesting();
    }
}
