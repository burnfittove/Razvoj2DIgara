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
        private readonly List<List<GameObject>> allItems = new();
        [SerializeField] private List<GameObject> regularItemPool = new();
        [SerializeField] private List<GameObject> shopItemPool = new();
        [SerializeField] private Transform itemSpawnLocation;
        [SerializeField] private GameObject fallbackItem;

        private void Awake()
        {
            Initialize();
            
            GameEventManager.Instance.itemEvents.OnCreateItemFromPool += GetItemFromPool;
        }

        private void Initialize()
        {
            allItems.Add(regularItemPool); 
            allItems.Add(shopItemPool);
        }

        private void GetItemFromPool(ItemPool pool)
        {
            // Choose item pool
            var itemPool = allItems[(int)pool];
            
            // If the item pool is empty, create the fallback item
            if (itemPool.Count == 0)
            {
                Instantiate(fallbackItem, itemSpawnLocation.position, Quaternion.identity);
                return;
            }
            // Get item
            int randId;
            do
            {
                randId = Random.Range(0, itemPool.Count);
            } while (!itemPool[randId]);
            
            // Create the item
            var item = itemPool[randId];
            Instantiate(item, itemSpawnLocation.position, Quaternion.identity);
            
            // Remove the item from the pool
            RemoveItemFromPools(item);
        }

        private void RemoveItemFromPools(GameObject item2Remove)
        {
            foreach (var itemPool in allItems)
            {
                foreach (var item in itemPool.Where(item => item == item2Remove).ToList()) itemPool.Remove(item);
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
