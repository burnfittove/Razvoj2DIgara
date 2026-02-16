using Events;
using PlayerScripts;
using UnityEngine;

namespace Item
{
    public class HealthBuyable : BuyableItem
    {
        protected override void Awake()
        {
            Initialize(PlayerInfo.Instance.Health);
            base.Awake();
        }

        protected override void SetColliderState()
        {
            item.meetsPickUpRequirements = item.ItemInformation.demonPrice <= playerAttribute.Value;
        }

        protected override void BuyItem()
        {
            GameEventManager.Instance.attributeUpdateEvents.MaxHealthChange(-item.ItemInformation.demonPrice);
        }
    }
}