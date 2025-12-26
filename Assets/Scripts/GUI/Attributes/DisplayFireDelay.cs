using Events;

namespace GUI.Attributes
{
    public class DisplayFireDelay : DisplayAttribute
    {
        protected override void SubscribeToAttributeEvent()
        {
            GameEventManager.Instance.attributeUpdateEvents.OnFireDelayChange += _ => DisplayValues();
            GameEventManager.Instance.attributeUpdateEvents.OnFireDelayMultiplierChange += _ => DisplayValues();
        }

        protected override void UpdateValues()
        {
            displayPrimaryValue = player.FireDelay.Value;
            displaySecondaryValue = player.FireDelay.Multiplier;
        }
    }
}