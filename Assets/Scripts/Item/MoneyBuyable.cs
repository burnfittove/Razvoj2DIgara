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
            item.meetsPickUpRequirements = item.ItemInformation.price <= playerAttribute.Value;
        }

        protected override void BuyItem()
        {
            GameEventManager.Instance.attributeUpdateEvents.MoneyChange(-item.ItemInformation.price);
        }
    }
}