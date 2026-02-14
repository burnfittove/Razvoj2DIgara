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
    }
}
