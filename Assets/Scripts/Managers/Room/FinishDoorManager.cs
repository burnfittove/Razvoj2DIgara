using System;
using Events;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Managers.Room
{
    public class FinishDoorManager : MonoBehaviour
    {
        public Sprite doorOpen;
        public Sprite doorClosed;
        public string hardCodedNextScene;
        private SpriteRenderer sr;
        private Collider2D col;

        private void Awake()
        {
            // Get component references
            sr = GetComponentInChildren<SpriteRenderer>();
            col = GetComponent<Collider2D>();
            
            // Initialize sprite
            sr.sprite = doorClosed;
            col.enabled = false;
            
            // Subscribe to events
            GameEventManager.Instance.roomEvents.OnRoomCleared += OpenDoor;
        }

        private void OpenDoor()
        {
            sr.sprite = doorOpen;
            col.enabled = true;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.CompareTag("Player")) return;
            
            // ##### DEBUG #####
            if (hardCodedNextScene != "")
            {
                SceneManager.LoadScene(hardCodedNextScene);
                return;
            }
            // #################
            
            GameEventManager.Instance.roomEvents.ChangeRoom();
        }

        private void OnDisable()
        {
            GameEventManager.Instance.roomEvents.OnRoomCleared -= OpenDoor;
        }
    }
}
