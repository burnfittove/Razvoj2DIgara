using Events;
using UnityEngine;

namespace Managers
{
    public class PlayerManager : MonoBehaviour
    {
        public float timeUntilSceneChange = 2.5f;
        private bool playerIsDead;
        private bool hasLoaded;

        private void Start()
        {
            GameEventManager.Instance.miscEvents.OnPlayerDied += PlayerDied;
        }

        private void Update()
        {
            if (!playerIsDead) return;
            timeUntilSceneChange -= Time.deltaTime;

            if (timeUntilSceneChange > 0) return;
            if (hasLoaded) return;
            GameEventManager.Instance.audioEvents.StopMusic();
            RoomManager.Instance.ChangeToDeathScene();
            hasLoaded = true;
        }

        private void PlayerDied()
        {
            playerIsDead = true;
        }
    }
}