using System;
using System.Collections.Generic;
using System.Linq;
using Events;
using UnityEngine;
using UnityEngine.InputSystem;
using Random = UnityEngine.Random;

namespace Managers
{
    /// <summary>
    /// The GameObject arrays are used to add prefabs from the editor. Later, during Awake, the prefabs in these arrays are added to a dictionary in itemId, GameObject pairs.
    /// </summary>
    public class ItemManager : MonoBehaviour
    {
        private readonly Dictionary<ItemPool, List<GameObject>> allItems = new();
        [SerializeField] private List<GameObject> regularItemPool = new();
        [SerializeField] private List<GameObject> shopItemPool = new();
        [SerializeField] private List<GameObject> demonItemPool = new();
        [SerializeField] private Transform itemSpawnLocation;
        [SerializeField] private GameObject fallbackItem;

        private void Awake()
        {
            Initialize();
        }

        private void Initialize()
        {
            allItems.Add(ItemPool.RegularPool, regularItemPool);
            allItems.Add(ItemPool.ShopPool, shopItemPool);
            allItems.Add(ItemPool.DemonPool, demonItemPool);
        }

        public GameObject GetItemFromPool(ItemPool pool)
        {
            // Get item pool
            var itemPool = allItems[pool];
            
            // If there are no items left in the pool, return null
            if (itemPool.Count == 0) return null;
            
            // Get random id from pool
            var randomIndex = Random.Range(0, itemPool.Count);
            var item = itemPool[randomIndex];
            
            // Remove the item from item pools
            RemoveItemFromPools(item);
            
            // Return the item
            return item;
        }

        private void RemoveItemFromPools(GameObject item2Remove)
        {
            // Remove the item from every item pool because the player shouldn't have two of the same item, normally 
            foreach (var itemPool in allItems.Values)
            {
                for (var i = 0; i < itemPool.Count; i++)
                {
                    if (itemPool[i] == item2Remove) itemPool.RemoveAt(i);
                }
            }
        }
        
        // private void Update()
        // {
        //     if (Keyboard.current.enterKey.wasPressedThisFrame) GameEventManager.Instance.itemEvents.CreateItemFromPool(ItemPool.RegularPool);
        //     
        //     Debug.Log($"REGULAR ITEM POOL COUNT: {regularItemPool.Count}");
        //     Debug.Log($"SHOP ITEM POOL COUNT: {shopItemPool.Count}");
        // }
    }
}
