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
        [SerializeField] private List<GameObject> vampireItemPool = new();
        [SerializeField] private Transform itemSpawnLocation;
        [SerializeField] private GameObject fallbackItem;
        [SerializeField] private GameObject penny;

        private void Awake()
        {
            allItems.Add(ItemPool.RegularPool, regularItemPool);
            allItems.Add(ItemPool.ShopPool, shopItemPool);
            allItems.Add(ItemPool.VampirePool, vampireItemPool);

            GameEventManager.Instance.itemEvents.OnCreateItemById += CreateItemById;
            GameEventManager.Instance.itemEvents.OnGetPenny += GetPenny;
            GameEventManager.Instance.itemEvents.OnGetItemFromPool += GetItemFromPool;
        }

        // Returns an item by its ID
        private void CreateItemById(GameObject obj, Vector2 pos)
        {
            // Get the item id
            var itemId = obj.GetComponent<Item.Item>().ItemInformation.itemId;
            var itemFound = false;
            
            // Find the first instance of the item in any item pool
            foreach (var itemPool in allItems.Values)   // Search all item pools
            {
                foreach (var item in itemPool)  // Search specific item pool
                {
                    if (item.GetComponent<Item.Item>().ItemInformation.itemId != itemId) continue;
                    // Create the found item and remove it from item pools
                    Instantiate(obj, pos, Quaternion.identity);
                    itemFound = true;
                    RemoveItemFromPools(item);
                    break;
                }

                if (itemFound) break;
            }
        }

        // Returns a random item from a specified pool
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
            
            // Return a copy of the item
            var itemCopy = Instantiate(item);
            itemCopy.SetActive(false);
            return itemCopy;
        }
        
        // Returns a penny
        private GameObject GetPenny()
        {
            // Return a copy of the prefab
            var obj = Instantiate(penny);
            obj.SetActive(false);
            return obj;
        }

        // Removes all instances of an item from all pools
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
