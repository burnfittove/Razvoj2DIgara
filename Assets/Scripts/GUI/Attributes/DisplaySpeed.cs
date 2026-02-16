using Events;
using PlayerScripts;

namespace GUI.Attributes
{
    public class DisplaySpeed : DisplayAttribute
    {
        protected override void SubscribeToAttributeEvent()
        {
            GameEventManager.Instance.attributeUpdateEvents.OnSpeedChange += _ => DisplayValues();
            GameEventManager.Instance.attributeUpdateEvents.OnSpeedMultiplierChange += _ => DisplayValues();
        }

        protected override void UpdateValues()
        {
            displayPrimaryValue = PlayerInfo.Instance.Speed.Value;
            displaySecondaryValue = PlayerInfo.Instance.Speed.Multiplier;
        }
    }
}