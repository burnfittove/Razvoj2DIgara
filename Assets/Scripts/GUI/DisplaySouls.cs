using Events;
using Managers;

namespace GUI
{
    public class DisplaySouls : DisplayValueWithTMPText
    {
        protected override void Awake()
        {
            base.Awake();
            GameEventManager.Instance.pickupEvents.OnSoulPickUp += amount => value += amount; 
        }

        protected override void UpdateText()
        {
            tmpText.text = $"{value}";
        }

        private void LateUpdate()
        {
            UpdateText();
        }
    }
}