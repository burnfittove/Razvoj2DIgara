using System;
using UnityEngine;

namespace GUI
{
    public class DisplayLuck : DisplayAttribute
    {
        private void Update()
        {
            attributeValue = player.Luck.Value;
            multiplierValue = player.Luck.Multiplier;
        }
    }
}
