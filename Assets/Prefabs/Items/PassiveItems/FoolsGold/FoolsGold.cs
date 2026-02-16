using Events;
using Item.PassiveItem;
using PlayerScripts;
using UnityEngine;

namespace Prefabs.Items.PassiveItems.FoolsGold
{
    public class FoolsGold : PassiveItem
    {
        protected override void OnItemPickedUp()
        {
            GameEventManager.Instance.pickupEvents.OnCurrencyPickUp += val =>
            {
                var rand = Random.Range(0, 100);
                if (!(rand <= PlayerInfo.Instance.Luck.Value)) return;
                GameEventManager.Instance.attributeUpdateEvents.MoneyChange(val);
            };
            base.OnItemPickedUp();
        }
    }
}