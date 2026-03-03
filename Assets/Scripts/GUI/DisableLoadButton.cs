using System;
using Saving;
using UnityEngine;
using UnityEngine.UI;

namespace GUI
{
    public class DisableLoadButton : MonoBehaviour
    {
        private void Start()
        {
            var temp = new SaveDataManager();
            GetComponent<Button>().interactable = temp.SaveFileExists();
        }
    }
}
