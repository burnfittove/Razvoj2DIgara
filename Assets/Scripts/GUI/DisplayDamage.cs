using System;

namespace GUI
{
    public class DisplayDamage : DisplayAttribute
    {
        private void Update()
        {
            attributeValue = player.Damage.Value;
            multiplierValue = player.Damage.Multiplier;
        }
    }
}
