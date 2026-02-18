using Events;
using PlayerScripts;

namespace GUI.Attributes
{
    public class DisplayRange : DisplayAttribute
    {
        protected override void SubscribeToAttributeEvent()
        {
            GameEventManager.Instance.attributeUpdateEvents.OnRangeChange += _ => DisplayValues();
            GameEventManager.Instance.attributeUpdateEvents.OnRangeMultiplierChange += _ => DisplayValues();
        }

        protected override void UpdateValues()
        {
            displayPrimaryValue = PlayerInfo.Instance.Range.Value;
            displaySecondaryValue = PlayerInfo.Instance.Range.Multiplier;
        }
    }
}