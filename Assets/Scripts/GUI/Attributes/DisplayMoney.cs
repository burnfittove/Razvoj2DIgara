using Events;
using PlayerScripts;

namespace GUI.Attributes
{
    public class DisplayMoney : DisplayAttribute
    {
        protected override void SubscribeToAttributeEvent()
        {
            GameEventManager.Instance.pickupEvents.OnCurrencyPickUp += _ => DisplayValues();
            GameEventManager.Instance.attributeUpdateEvents.OnMoneyChange += _ => DisplayValues();
        }

        protected override void UpdateValues()
        {
            displayPrimaryValue = PlayerInfo.Instance.Money.Value;
        }

        protected override void DisplayValues()
        {
            UpdateValues();
            
            tmpText.text = $"{attributeName}: {displayPrimaryValue}";
        }
    }
}