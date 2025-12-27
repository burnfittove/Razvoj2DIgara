using Events;
using Item.PassiveItem;
using UnityEngine;

namespace Items.PassiveItems.FoolsGold
{
    public class FoolsGold : PassiveItem
    {
        protected override void OnItemPickedUp()
        {
            GameEventManager.Instance.pickupEvents.OnCurrencyPickUp += val =>
            {
                var rand = Random.Range(0, 100);
                if (!(rand <= player.Luck.Value)) return;
                player.Money.UpdateValue(val);
            };
            base.OnItemPickedUp();
        }
    }
}