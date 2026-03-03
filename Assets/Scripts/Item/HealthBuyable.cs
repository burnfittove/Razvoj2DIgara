using Events;
using PlayerScripts;
using UnityEngine;

namespace Item
{
    public class HealthBuyable : BuyableItem
    {
        protected override void Awake()
        {
            Initialize(PlayerInfo.Instance.MaxHealth);
            base.Awake();
        }

        protected override void SetColliderState()
        { 
            item.meetsPickUpRequirements = item.itemInformation.vampirePrice <= playerAttribute.value;
            Debug.Log(item.meetsPickUpRequirements);
        }

        protected override void BuyItem()
        {
            GameEventManager.Instance.attributeUpdateEvents.MaxHealthChange(-item.itemInformation.vampirePrice);
        }
    }
}