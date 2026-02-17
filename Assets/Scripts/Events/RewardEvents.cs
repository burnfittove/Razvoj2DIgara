using System;
using Currencies.Money;
using Managers;
using UnityEngine;

namespace Events
{
    public class RewardEvents
    {
        // Called when a script wants to reward the player with an item
        public event Func<ItemPool, GameObject> OnRewardItem;
        public GameObject RewardItem(ItemPool itemPool)
        {
            return OnRewardItem?.Invoke(itemPool);
        }
        
        // Called when a script wants to reward the player with money
        public event Func<MoneyValue, GameObject> OnRewardMoney;
        public GameObject RewardMoney(MoneyValue arg)
        {
            return OnRewardMoney?.Invoke(arg);
        }

        // Called when a script wants to reward the player with a soul
        public event Func<GameObject> OnRewardSoul;
        public GameObject RewardSoul()
        {
            return OnRewardSoul?.Invoke();
        }
    }
}
