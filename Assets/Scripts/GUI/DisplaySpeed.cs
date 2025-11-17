using System;
using UnityEngine;

namespace GUI
{
    public class DisplaySpeed : DisplayAttribute
    {
        private void Update()
        {
            attributeValue = player.Speed.Value;
            multiplierValue = player.Speed.Multiplier;
        }
    }
}
