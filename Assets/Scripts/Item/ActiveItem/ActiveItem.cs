using System;
using System.Collections;
using Events;
using UnityEngine;

namespace Item.ActiveItem
{
    public class ActiveItem : Item
    {
        public int currentCharge;
        protected override void OnItemPickedUp()
        {
            GameEventManager.Instance.itemEvents.ActiveItemAcquired(gameObject);
            HideItem();
        }

        private void Start()
        {
            currentCharge = itemInformation.maxCharge;
        }
    }
}
