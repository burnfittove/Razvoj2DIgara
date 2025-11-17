using System;
using UnityEngine;

namespace GUI
{
    public class DisplayShotSpeed : DisplayAttribute
    {
        private void Update()
        {
            attributeValue = player.ShotSpeed.Value;
            multiplierValue = player.ShotSpeed.Multiplier;
        }
    }
}
