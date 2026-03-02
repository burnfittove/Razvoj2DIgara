using Events;
using Saving;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Managers
{
    public class MainMenuManager : MonoBehaviour
    {
        public string startRoomScene;
        public string loadScene;
        private void Start()
        {
            GameEventManager.Instance.mainMenuEvents.OnStartGame += StartGame;
            GameEventManager.Instance.mainMenuEvents.OnLoadGame += LoadGame;
        }

        private void StartGame()
        {
            SceneManager.LoadScene(startRoomScene);
        }

        private void LoadGame()
        {
            var temp = new SaveDataManager();
            if (temp.SaveFileExists()) SceneManager.LoadScene(loadScene);
        }
        
        public void OnPressedStartGame()
        {
            GameEventManager.Instance.mainMenuEvents.StartGame();
        }
        
        public void OnPressedLoadGame()
        {
            GameEventManager.Instance.mainMenuEvents.LoadGame();
        }
    }
}