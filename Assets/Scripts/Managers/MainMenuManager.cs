using Events;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Managers
{
    public class MainMenuManager : MonoBehaviour
    {
        public string startRoomScene;
        private void Start()
        {
            GameEventManager.Instance.mainMenuEvents.OnStartGame += StartGame;
        }

        private void StartGame()
        {
            SceneManager.LoadScene(startRoomScene);
        }
        
        public void OnPressedStartGame()
        {
            GameEventManager.Instance.mainMenuEvents.StartGame();
        }
    }
}