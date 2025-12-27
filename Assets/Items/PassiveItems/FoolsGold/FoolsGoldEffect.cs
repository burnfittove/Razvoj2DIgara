using Events;
using Items.ItemEffects;
using UnityEngine;

namespace Items.PassiveItems.FoolsGold
{
    public class FoolsGoldEffect : PassiveItemEffect
    {
        protected override void Awake()
        {
            base.Awake();
            GameEventManager.Instance.pickupEvents.OnCurrencyPickUp += val =>
            {
                Random.InitState((int)player.Money.Value + 1);
                if (Random.Range(0, 100) <= player.Luck.Value) player.Money.UpdateValue(val);
            };
        }
    }
}
