using Currencies.Money;
using Events;
using UnityEngine;

namespace Managers
{
    public class RewardManager : MonoBehaviour
    {
        // Singleton
        public static RewardManager Instance { get; private set; }
        
        [Header("Soul")]
        [SerializeField] private GameObject soulPrefab;
        
        [Header("Money")]
        // ##### PENNY #####
        [SerializeField] private GameObject pennyPrefab;
        // ##### NICKEL #####
        [SerializeField] private GameObject nickelPrefab;
        // ##### DIME #####
        [SerializeField] private GameObject dimePrefab;
        // ##### QUARTER #####
        [SerializeField] private GameObject quarterPrefab;
        
        private void Awake()
        {
            // Singleton
            if (Instance != null && Instance != this) Debug.LogError("Multiple instances of RewardManager detected!");
            Instance = this;
        }

        public GameObject GetRewardItem(ItemPool itemPool)
        {
            return GameEventManager.Instance.itemEvents.GetItemFromPool(itemPool);
        }

        public GameObject GetRewardMoney(MoneyValue moneyValue)
        {
            switch (moneyValue)
            {
                case MoneyValue.Quarter:
                    return GetItemCopy(quarterPrefab);
                case MoneyValue.Dime:
                    return GetItemCopy(dimePrefab);
                case MoneyValue.Nickel:
                    return GetItemCopy(nickelPrefab);
                case MoneyValue.Penny:
                    default:
                        return GetItemCopy(pennyPrefab);
            }
        }

        public GameObject GetRewardSoul()
        {
            return GetItemCopy(soulPrefab);
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
