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
        private Dictionary<ItemPool, Dictionary<int, GameObject>> allItems = new();
        [Header("Editor only")] 
        [SerializeField] private GameObject[] editorRegularItemPool;
        [SerializeField] private GameObject[] editorShopItemPool;
        [SerializeField] private Transform itemSpawnLocation;
        [SerializeField] private GameObject fallbackItem;
        [Header("For use")]
        private Dictionary<int, GameObject> regularItemPool = new();
        private Dictionary<int, GameObject> shopItemPool = new();
        private int regularItemPoolSize;
        private int shopItemPoolSize;

        private void Awake()
        {
            Initialize();
            
            GameEventManager.Instance.itemEvents.OnCreateItemFromPool += GetItemFromPool;
        }

        private void Update()
        {
            if (Keyboard.current.enterKey.wasPressedThisFrame) GameEventManager.Instance.itemEvents.CreateItemFromPool(ItemPool.RegularPool);
            
            Debug.Log($"REGULAR ITEM POOL COUNT: {regularItemPool.Count}");
            Debug.Log($"SHOP ITEM POOL COUNT: {shopItemPool.Count}");
        }

        private void Initialize()
        {
            // Fill dictionaries
            FillDictionary(regularItemPool, editorRegularItemPool);
            FillDictionary(shopItemPool, editorShopItemPool);
            
            // Set dictionary sizes
            regularItemPoolSize = regularItemPool.Count;
            shopItemPoolSize = shopItemPool.Count;
            
            // Put item pools in allItems
            allItems.Add(ItemPool.RegularPool, regularItemPool);
            allItems.Add(ItemPool.ShopPool, shopItemPool);
        }

        private void FillDictionary(Dictionary<int, GameObject> dictionary, GameObject[] items)
        {
            // Fills dictionary with array values for quick access
            foreach (var item in items)
            {
                dictionary.Add(item.GetComponent<Item.Item>().ItemInformation.itemId, item);
            }

            // Set editor array as null so it's cleaned by garbage collection
            // The idea is that all of this initialization only happens at the start of the run and these dictionaries persist through different scenes, if this turns out to be impossible then it will have to happen at the start of each room and the arrays will have to stay in memory
            //editorRegularItemPool = null;
        }

        private void RemoveItemFromPools(int itemId)
        {
            // Remove the item from all item pools by its ID
            foreach (var itemPool in allItems.Values)
            {
                itemPool.Remove(itemId);
            }
        }

        private void GetItemFromPool(ItemPool pool)
        {
            // Get item pool
            var itemPool = allItems[pool];
            // Get item ID
            // If there is only one item left in the dictionary 
            if (itemPool.Count == 0)
            {
                Instantiate(fallbackItem, itemSpawnLocation.position, Quaternion.identity);          // FOR SOME REASON THIS CRASHES THE GAME
                return;
            }
            int randId;
            do
            {
                randId = Random.Range(0, itemPool.Count);
            } while (!itemPool.ContainsKey(randId));
            // Create item on desired location
            Instantiate(itemPool[randId], itemSpawnLocation.position, Quaternion.identity);
            // Remove the created item from all item pools
            RemoveItemFromPools(randId);           // FOR SOME REASON THIS CRASHES THE GAME WHEN THE FINAL ITEM IS REMOVED
        }
    }
}
