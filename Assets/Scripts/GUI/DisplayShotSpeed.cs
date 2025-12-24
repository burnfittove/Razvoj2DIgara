using System;
using UnityEngine;

namespace GUI
{
    public class DisplayShotSpeed : DisplayAttribute
    {
        private void Update()
        {
            value = player.ShotSpeed.Value;
            multiplierValue = player.ShotSpeed.Multiplier;
        }
    }
}
