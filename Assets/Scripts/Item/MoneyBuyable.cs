using Events;
using PlayerScripts;
using UnityEngine;

namespace Item
{
    public class MoneyBuyable : BuyableItem
    {
        protected override void Initialize()
        {
            GameObject.FindGameObjectWithTag("Player").TryGetComponent(out Player player);
            playerAttribute = player.Money;
            TryGetComponent(out item);
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