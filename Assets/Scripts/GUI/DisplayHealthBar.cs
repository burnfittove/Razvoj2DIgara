using System;
using Events;
using PlayerScripts;
using UnityEngine;
using UnityEngine.UI;
using Attribute = PlayerScripts.Attribute;

namespace GUI
{
    public class DisplayHealthBar : MonoBehaviour
    {
        private Player player;
        private float attributeValue;
        private float maxAttributeValue;
        private Slider slider;
        
        private void Awake()
        {
            player = GameObject.FindWithTag("Player").GetComponent<Player>();
            slider = GetComponent<Slider>();
        }

        protected void LateUpdate()
        {
            // Update values
            attributeValue = player.Health.Value;
            maxAttributeValue = player.MaxHealth.Value;
            
            // Update GUI
            slider.maxValue = maxAttributeValue;
            slider.value = attributeValue;
        }
    }
}