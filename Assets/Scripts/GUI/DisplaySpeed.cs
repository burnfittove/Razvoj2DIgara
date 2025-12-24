using System;
using UnityEngine;

namespace GUI
{
    public class DisplaySpeed : DisplayAttribute
    {
        private void Update()
        {
            value = player.Speed.Value;
            multiplierValue = player.Speed.Multiplier;
        }
    }
}
