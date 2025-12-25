using Events;

namespace GUI.Attributes
{
    public class DisplayLuck : DisplayAttribute
    {
        protected override void SubscribeToAttributeEvent()
        {
            GameEventManager.Instance.attributeUpdateEvents.OnLuckChange += _ => DisplayValues();
            GameEventManager.Instance.attributeUpdateEvents.OnLuckMultiplierChange += _ => DisplayValues();
        }

        protected override void UpdateValues()
        {
            displayPrimaryValue = player.Luck.Value;
            displaySecondaryValue = player.Luck.Multiplier;
        }
    }
}