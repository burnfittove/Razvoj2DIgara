using Events;
using PlayerScripts;
using UnityEngine;

namespace Item
{
    public class SoulBuyable : BuyableItem
    {
        protected override void Awake()
        {
            Initialize(PlayerInfo.Instance.Souls);
            base.Awake();
        }

        protected override void SetColliderState()
        { 
            item.meetsPickUpRequirements = item.itemInformation.vampirePrice <= playerAttribute.value;
        }

        protected override void BuyItem()
        {
            GameEventManager.Instance.attributeUpdateEvents.SoulChange(-item.itemInformation.vampirePrice);
        }
    }
}