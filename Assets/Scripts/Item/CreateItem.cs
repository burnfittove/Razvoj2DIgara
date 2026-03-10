using System;
using Events;
using Managers;
using UnityEngine;

namespace Item
{
    public class CreateItem : MonoBehaviour
    {
        [Header("Spawn random item")]
        [SerializeField] private ItemPool itemPool;
        [Header("Spawn by item ID")]
        [SerializeField] private bool useItemId;
        [SerializeField] private int itemId;
        [Header("Spawn as purchasable")]
        [SerializeField] private bool isPurchasable;

        private void Start()
        {
            // Get item from ItemManager
            var item = GameEventManager.Instance.itemEvents.GetItemFromPool(itemPool);
            
            // If the item is purchasable, add the corresponding monetization type
            if (isPurchasable)
            {
                switch (itemPool)
                {
                    case ItemPool.ShopPool:
                        item.AddComponent<MoneyBuyable>();
                        break;
                    case ItemPool.VampirePool:
                        item.AddComponent<SoulBuyable>();
                        break;
                    case ItemPool.RegularPool:
                    default:
                        break;
                }
            }
            
            // Show the item
            item.transform.position = transform.position;
            item.SetActive(true);

            // // Instantiate from ItemManager
            // if (!GameObject.FindGameObjectWithTag("ItemManager").TryGetComponent(out ItemManager itemManager)) Destroy(gameObject);
            // var item = Instantiate(itemManager.GetItemFromPool(itemPool), transform.position, Quaternion.identity);
            //
            // // Add a component to the item determined by which pool it was taken from
            // switch (itemPool)
            // {
            //     case ItemPool.ShopPool:
            //         item.AddComponent<MoneyBuyable>();
            //         break;
            //     case ItemPool.VampirePool:
            //         item.AddComponent<HealthBuyable>();
            //         break;
            // }
        }
    }
}
