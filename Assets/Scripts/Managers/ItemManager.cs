using System.Collections.Generic;
using System.Linq;
using Events;
using UnityEngine;
using UnityEngine.InputSystem;

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

        private void Awake()
        {
            Initialize();
            
            GameEventManager.Instance.itemEvents.OnCreateItemFromPool += GetItemFromPool;
        }

        private void Initialize()
        {
            // Fill dictionaries
            FillDictionary(regularItemPool, editorRegularItemPool);
            FillDictionary(shopItemPool, editorShopItemPool);
            
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
                if (!itemPool.ContainsKey(itemId)) continue;
                itemPool[itemId] = null;
            }
        }

        private void GetItemFromPool(ItemPool pool)
        {
            // Get item pool
            var itemPool = allItems[pool];
            // Get item ID
            // If there is only one item left in the dictionary 
            if (itemPool.Count == 1)
            {
                Instantiate(itemPool[0], itemSpawnLocation.position, Quaternion.identity);          // THIS NEEDS TO BE CHANGED SO IT CREATES THE DEFAULT ITEM
                return;
            }
            int randId;
            do
            {
                randId = Random.Range(0, itemPool.Count);
                Debug.Log($"I chose: {randId}");
            } while (!itemPool[randId]);
            // Create item on desired location
            Instantiate(itemPool[randId], itemSpawnLocation.position, Quaternion.identity);
            // Remove the created item from all item pools
            if (randId != 0) RemoveItemFromPools(randId);           // THIS NEEDS TO ALSO INCLUDE THE FIRST ITEM
        }
    }
}
