using Events;
using PlayerScripts;

namespace GUI.Attributes
{
    public class DisplayDamage : DisplayAttribute
    {
        protected override void SubscribeToAttributeEvent()
        {
            GameEventManager.Instance.attributeUpdateEvents.OnDamageChange += _ => DisplayValues();
            GameEventManager.Instance.attributeUpdateEvents.OnDamageMultiplierChange += _ => DisplayValues();
        }

        protected override void UpdateValues()
        {
            displayPrimaryValue = PlayerInfo.Instance.Damage.Value;
            displaySecondaryValue = PlayerInfo.Instance.Damage.Multiplier;
        }
    }
}