using Events;
using PlayerScripts;
using UnityEngine;

namespace Item
{
    public class MoneyBuyable : BuyableItem
    {
        protected override void Awake()
        {
            Initialize(PlayerInfo.Instance.Money);
            base.Awake();
        }

        protected override void SetColliderState()
        {
            item.meetsPickUpRequirements = item.itemInformation.price <= playerAttribute.value;
        }

        protected override void BuyItem()
        {
            GameEventManager.Instance.attributeUpdateEvents.MoneyChange(-item.itemInformation.price);
        }
    }
}