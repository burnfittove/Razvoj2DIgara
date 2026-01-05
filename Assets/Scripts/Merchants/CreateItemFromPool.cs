using System;
using Managers;
using PlayerScripts;
using UnityEngine;

namespace Merchants
{
    public class CreateItemFromPool : MonoBehaviour
    {
        [SerializeField] private ItemManager itemManager;
        [SerializeField] private ItemPool itemPool;
        private GameObject itemPrefab;
        
        private void Awake()
        {
            GameObject.FindGameObjectWithTag("ItemManager").TryGetComponent(out itemManager);
            
            if (!itemManager) Destroy(gameObject);

            CreateItem();
        }

        private void CreateItem()
        {
            // Get the item
            itemPrefab = itemManager.GetItemFromPool(itemPool);
            
            // Add component depending on the pool
            switch (itemPool)
            {
                case ItemPool.RegularPool:
                    break;
                case ItemPool.ShopPool:
                    itemPrefab.AddComponent(typeof(ShopItem));
                    break;
                case ItemPool.DemonPool:
                    break;
            }
        }
    }
}
