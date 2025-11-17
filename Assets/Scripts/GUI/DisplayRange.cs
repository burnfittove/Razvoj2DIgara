using System;
using UnityEngine;

namespace GUI
{
    public class DisplayRange : DisplayAttribute
    {
        private void Update()
        {
            attributeValue = player.Range.Value;
            multiplierValue = player.Range.Multiplier;
        }
    }
}
