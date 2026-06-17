using System;
using Currencies.Money;
using Events;
using Managers;
using PlayerScripts;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Prefabs.Items.ActiveItem.MoneyPrinter
{
    public class MoneyPrinter : Item.ActiveItem.ActiveItem
    {
        [SerializeField] private int changeToCreateQuarter;
        public override void UseActiveItem()
        {
            base.UseActiveItem();
            var chance = Random.Range(0, 10);
            // If the chance is lower than the player's luck, get a penny from the RewardManager
            if (chance > PlayerInfo.Instance.Luck.value) return;
            var obj = RewardManager.Instance.GetRewardMoney(MoneyValue.Dime);
            Random.InitState(DateTime.Now.Millisecond);
            obj.transform.position = (Vector2)player.transform.position + new Vector2(Random.Range(1.25f, 1.4f), Random.Range(1.25f, 1.4f));
            obj.SetActive(true);
        }

        protected override void OnItemPickedUp()
        {
            GameEventManager.Instance.roomEvents.OnRoomCleared += IncreaseCharge;
            base.OnItemPickedUp();
        }
    }
}
