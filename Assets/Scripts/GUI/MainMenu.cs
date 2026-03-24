using Saving;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GUI
{
    public class MainMenu : MonoBehaviour
    {
        public void ReturnToMainMenu()
        {
            var temp = new SaveDataManager();
            temp.DeleteSaveFile();
            SceneManager.LoadScene("MainMenu");
        }
    }
}
