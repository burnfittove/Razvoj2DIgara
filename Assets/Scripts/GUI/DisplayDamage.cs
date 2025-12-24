using System;

namespace GUI
{
    public class DisplayDamage : DisplayAttribute
    {
        private void Update()
        {
            value = player.Damage.Value;
            multiplierValue = player.Damage.Multiplier;
        }
    }
}
