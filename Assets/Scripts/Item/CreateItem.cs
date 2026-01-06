using System;
using Managers;
using UnityEngine;

namespace Item
{
    public class CreateItem : MonoBehaviour
    {
        [SerializeField] private ItemPool itemPool;

        private void Start()
        {
            // Instantiate from ItemManager
            if (!GameObject.FindGameObjectWithTag("ItemManager").TryGetComponent(out ItemManager itemManager)) Destroy(gameObject);
            var item = Instantiate(itemManager.GetItemFromPool(itemPool), transform.position, Quaternion.identity);
            
            // Add a component to the item determined by which pool it was taken from 
            switch (itemPool)
            {
                case ItemPool.ShopPool:
                    item.AddComponent<MoneyBuyable>();
                    break;
                case ItemPool.DemonPool:
                    item.AddComponent<HealthBuyable>();
                    break;
            }
        }
    }
}
