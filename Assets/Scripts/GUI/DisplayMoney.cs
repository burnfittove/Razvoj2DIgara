using System;
using Events;
using Managers;
using UnityEngine;

namespace GUI
{
    public class DisplayMoney : DisplayValueWithTMPText
    {
        protected override void Awake()
        {
            base.Awake();
            GameEventManager.Instance.pickupEvents.OnCurrencyPickUp += amount => value += amount; 
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