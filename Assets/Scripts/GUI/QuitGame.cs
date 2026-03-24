using Saving;
using UnityEngine;

namespace GUI
{
    public class QuitGame : MonoBehaviour
    {
        public void QuitGameButton()
        {
            var temp = new SaveDataManager();
            temp.DeleteSaveFile();
            Application.Quit();
        }
    }
}
