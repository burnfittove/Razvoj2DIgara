using System;
using System.Collections;
using Events;
using PlayerScripts;
using UnityEngine;

namespace Prefabs.Items.ActiveItem.Focus
{
    public class Focus : Item.ActiveItem.ActiveItem
    {
        [SerializeField] private float time;
        private float timeBuffer;

        public override void UseActiveItem()
        {
            base.UseActiveItem();
            
            // Decrease fire rate multiplier
            GameEventManager.Instance.attributeUpdateEvents.FireDelayMultiplierChange(itemInformation.fireDelayMultiplierDelta);
            
            // Set time
            timeBuffer = time;
        }

        private void Update()
        {
            // If timeBuffer is lesser than zero, return
            if (timeBuffer <= 0) return;
            
            // Decrease the timer
            timeBuffer -= Time.deltaTime;
            
            // Increase the fire rate multiplier if the time has run out
            if (timeBuffer <= 0) GameEventManager.Instance.attributeUpdateEvents.FireDelayMultiplierChange(2);
        }
    }
}
