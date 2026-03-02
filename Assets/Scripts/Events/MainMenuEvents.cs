using System;
using UnityEngine;

namespace Events
{
    public class MainMenuEvents
    {
        public event Action OnStartGame;
        public void StartGame()
        {
            OnStartGame?.Invoke();
        }
        
        public event Action OnLoadGame;
        public void LoadGame()
        {
            OnLoadGame?.Invoke();
        }
    }
}
