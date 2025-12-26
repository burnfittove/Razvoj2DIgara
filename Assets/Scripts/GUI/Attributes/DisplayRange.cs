using Events;

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
            displayPrimaryValue = player.Range.Value;
            displaySecondaryValue = player.Range.Multiplier;
        }
    }
}