using System;
using Events;
using UnityEngine;

namespace Managers
{
    public class PlayerManager : MonoBehaviour
    {
        public float timeUntilSceneChange = 2.5f;
        private bool playerIsDead = false;

        private void Start()
        {
            GameEventManager.Instance.miscEvents.OnPlayerDied += PlayerDied;
        }

        private void Update()
        {
            if (!playerIsDead) return;
            timeUntilSceneChange -= Time.deltaTime;
            
            if (timeUntilSceneChange <= 0) RoomManager.Instance.ChangeToDeathScene();
        }

        private void PlayerDied()
        {
            playerIsDead = true;
        }
    }
}