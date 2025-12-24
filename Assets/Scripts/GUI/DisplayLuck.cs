using System;
using UnityEngine;

namespace GUI
{
    public class DisplayLuck : DisplayAttribute
    {
        private void Update()
        {
            value = player.Luck.Value;
            multiplierValue = player.Luck.Multiplier;
        }
    }
}
