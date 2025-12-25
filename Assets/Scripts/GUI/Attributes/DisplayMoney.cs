using Events;

namespace GUI.Attributes
{
    public class DisplayMoney : DisplayAttribute
    {
        protected override void SubscribeToAttributeEvent()
        {
            GameEventManager.Instance.pickupEvents.OnCurrencyPickUp += _ => DisplayValues();
        }

        protected override void UpdateValues()
        {
            displayPrimaryValue = player.Money.Value;
        }

        protected override void DisplayValues()
        {
            UpdateValues();
            
            tmpText.text = $"{attributeName}: {displayPrimaryValue}";
        }
    }
}