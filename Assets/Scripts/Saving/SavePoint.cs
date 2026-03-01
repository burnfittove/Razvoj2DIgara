using System;
using UnityEngine;

namespace Saving
{
    public class SavePoint : MonoBehaviour
    {
        private SaveDataManager saveDataManager;

        private void Awake()
        {
            saveDataManager = new SaveDataManager();
            saveDataManager.LoadGame();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.CompareTag("Player")) return;
            saveDataManager.SaveGame();
        }
    }
}