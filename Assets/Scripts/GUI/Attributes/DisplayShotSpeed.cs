using Events;
using PlayerScripts;

namespace GUI.Attributes
{
    public class DisplayShotSpeed : DisplayAttribute
    {
        protected override void SubscribeToAttributeEvent()
        {
            GameEventManager.Instance.attributeUpdateEvents.OnShotSpeedChange += _ => DisplayValues();
            GameEventManager.Instance.attributeUpdateEvents.OnShotSpeedMultiplierChange += _ => DisplayValues();
        }

        protected override void UpdateValues()
        {
            displayPrimaryValue = PlayerInfo.Instance.ShotSpeed.Value;
            displaySecondaryValue = PlayerInfo.Instance.ShotSpeed.Multiplier;
        }
    }
}