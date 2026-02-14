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
        private static List<GameObject> regularItemPool = new();
        private static List<GameObject> shopItemPool = new();
        private static List<GameObject> vampireItemPool = new();
        [SerializeField] private Transform itemSpawnLocation;
        private static GameObject fallbackItem;
        private static GameObject penny;

        private void Awake()
        {
            allItems.Add(ItemPool.RegularPool, regularItemPool);
            allItems.Add(ItemPool.ShopPool, shopItemPool);
            allItems.Add(ItemPool.VampirePool, vampireItemPool);

            GameEventManager.Instance.itemEvents.OnGetItemById += GetItemById;
            GameEventManager.Instance.itemEvents.OnGetPenny += GetPenny;
            GameEventManager.Instance.itemEvents.OnGetItemFromPool += GetItemFromPool;
        }

        // Returns an item by its ID
        private GameObject GetItemById(int itemId)
        {
            // Get an item according to its ID from any pool
            foreach (var itemPool in allItems.Values)
            {
                foreach (var item in itemPool)
                {
                    // If the object doesn't have an item component, continue
                    if (!item.TryGetComponent<Item.Item>(out var itemComponent)) continue; // This is very inefficient, but fuck it, this method won't get used much anyway
                    // If the random item's ID doesn't equal the given ID, continue
                    if (itemComponent.ItemInformation.itemId != itemId) continue;
                    // GetItemCopy
                    return GetItemCopy(item);
                }
            }

            return fallbackItem;
        }

        // Returns a random item from a specified pool
        private GameObject GetItemFromPool(ItemPool pool)
        {
            // Get item pool
            var itemPool = allItems[pool];
            
            // If there are no items left in the pool, return the fallback item
            if (itemPool.Count == 0)
            {
                // Create the copy of the provided item
                var obj = Instantiate(fallbackItem);
                obj.SetActive(false);
                // Return the copy of the item
                return obj;
            }
            
            // Get random id from pool
            var randomIndex = Random.Range(0, itemPool.Count);
            var item = itemPool[randomIndex];
            
            // GetItemCopy
            return GetItemCopy(item);
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
                    // If the random item equals the provided item, remove it and stop the loop
                    if (itemPool[i] != item2Remove) continue;
                    itemPool.RemoveAt(i);
                    break;
                }
            }
        }

        // Return the instantiated object and remove it from all item pools 
        private GameObject GetItemCopy(GameObject item)
        {
            // Remove the item from all item pools
            RemoveItemFromPools(item);
            // Create the copy of the provided item
            var obj = Instantiate(item);
            obj.SetActive(false);
            // Return the copy of the item
            return obj;
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
