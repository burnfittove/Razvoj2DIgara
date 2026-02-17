using System;
using Currencies.Money;
using Events;
using UnityEngine;

namespace Managers
{
    public class RewardManager : MonoBehaviour
    {
        [Header("Soul")]
        [SerializeField] private GameObject soul;
        
        [Header("Money")]
        // ##### PENNY #####
        [SerializeField] private GameObject penny;
        // ##### NICKEL #####
        [SerializeField] private GameObject nickel;
        // ##### DIME #####
        [SerializeField] private GameObject dime;
        // ##### QUARTER #####
        [SerializeField] private GameObject quarter;
        
        private void Awake()
        {
            // Subscribe to RewardEvents events
            GameEventManager.Instance.rewardEvents.OnRewardItem += GetRewardItem;
            GameEventManager.Instance.rewardEvents.OnRewardMoney += GetRewardMoney;
            GameEventManager.Instance.rewardEvents.OnRewardSoul += GetRewardSoul;
        }

        private GameObject GetRewardItem(ItemPool itemPool)
        {
            return GameEventManager.Instance.itemEvents.GetItemFromPool(itemPool);
        }

        private GameObject GetRewardMoney(MoneyValue moneyValue)
        {
            switch (moneyValue)
            {
                case MoneyValue.Quarter:
                    return GetItemCopy(quarter);
                case MoneyValue.Dime:
                    return GetItemCopy(dime);
                case MoneyValue.Nickel:
                    return GetItemCopy(nickel);
                case MoneyValue.Penny:
                    default:
                        return GetItemCopy(penny);
            }
        }

        private GameObject GetRewardSoul()
        {
            return GetItemCopy(soul);
        }
        
        // Return the instantiated object and remove it from all item pools 
        private GameObject GetItemCopy(GameObject item)
        {
            // Create the copy of the provided item
            var obj = Instantiate(item);
            obj.SetActive(false);
            // Return the copy of the item
            return obj;
        }
    }
}
