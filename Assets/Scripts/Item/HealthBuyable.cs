using Events;
using PlayerScripts;
using UnityEngine;

namespace Item
{
    public class HealthBuyable : BuyableItem
    {
        protected override void Initialize()
        {
            GameObject.FindGameObjectWithTag("Player").TryGetComponent(out Player player);
            playerAttribute = player.MaxHealth;
            TryGetComponent(out item);
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