using System;
using UnityEngine;

namespace GUI
{
    public class DisplayFireDelay : DisplayAttribute
    {
        private void Update()
        {
            value = player.FireDelay.Value;
            multiplierValue = player.FireDelay.Multiplier;
        }
    }
}
