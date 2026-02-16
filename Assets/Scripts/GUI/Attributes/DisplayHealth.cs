using Events;
using PlayerScripts;
using TMPro;
using UnityEngine.UI;

namespace GUI.Attributes
{
    public class DisplayHealth : DisplayAttribute
    {
        private Slider slider;
        protected override void SubscribeToAttributeEvent()
        {
            GameEventManager.Instance.attributeUpdateEvents.OnHealthChange += _ => DisplayValues();
            GameEventManager.Instance.attributeUpdateEvents.OnMaxHealthChange += _ => DisplayValues();
        }

        protected override void UpdateValues()
        {
            displayPrimaryValue = PlayerInfo.Instance.Health.Value;
            displaySecondaryValue = PlayerInfo.Instance.MaxHealth.Value;
        }

        protected override void Awake()
        {
            base.Awake();
            // Initialize components
            tmpText = GetComponentInChildren<TMP_Text>();
            slider = GetComponentInChildren<Slider>();
        }

        protected override void DisplayValues()
        {
            UpdateValues();
            
            tmpText.text = $"{displayPrimaryValue:0.0}/{displaySecondaryValue:0.0}";
                
            slider.maxValue = displaySecondaryValue;
            slider.value = displayPrimaryValue;
        }
    }
}