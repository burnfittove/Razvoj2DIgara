using System;
using UnityEngine;

namespace Managers.Room
{
    public class SetPlayerPosition : MonoBehaviour
    {
        private void Awake()
        {
            GameObject.FindGameObjectWithTag("Player").transform.position = transform.position;
        }
    }
}
