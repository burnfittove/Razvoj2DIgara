using System;
using UnityEngine;

namespace GUI
{
    public class DisplayRange : DisplayAttribute
    {
        private void Update()
        {
            value = player.Range.Value;
            multiplierValue = player.Range.Multiplier;
        }
    }
}
