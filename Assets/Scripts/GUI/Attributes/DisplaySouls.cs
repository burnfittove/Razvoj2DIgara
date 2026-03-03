using Events;
using PlayerScripts;

namespace GUI.Attributes
{
    public class DisplaySouls : DisplayAttribute
    {
        protected override void SubscribeToAttributeEvent()
        {
            GameEventManager.Instance.pickupEvents.OnSoulPickUp += _ => DisplayValues();
            GameEventManager.Instance.attributeUpdateEvents.OnSoulChange += _ => DisplayValues();
        }

        protected override void UpdateValues()
        {
            displayPrimaryValue = PlayerInfo.Instance.Souls.value;
        }

        public override void DisplayValues()
        {
            UpdateValues();
            
            tmpText.text = $"{attributeName}: {displayPrimaryValue}";
        }
    }
}