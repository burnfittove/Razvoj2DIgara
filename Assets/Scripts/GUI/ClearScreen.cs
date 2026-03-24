using System;
using UnityEngine;

namespace GUI
{
    public class ClearScreen : MonoBehaviour
    {
        private void Awake()
        {
            GameObject.FindGameObjectWithTag("UI")?.SetActive(false);
            GameObject.FindGameObjectWithTag("Player")?.SetActive(false);
        }
    }
}
