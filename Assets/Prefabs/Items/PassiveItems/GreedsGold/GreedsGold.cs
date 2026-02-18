using Events;
using Item.PassiveItem;
using UnityEngine;

namespace Prefabs.Items.PassiveItems.GreedsGold
{
    public class GreedsGold : PassiveItem
    {
        protected override void OnItemPickedUp()
        {
            GameEventManager.Instance.pickupEvents.OnCurrencyPickUp += val =>
            {
                GameEventManager.Instance.attributeUpdateEvents.MoneyChange(val);
            };
            base.OnItemPickedUp();
        }
    }
}
