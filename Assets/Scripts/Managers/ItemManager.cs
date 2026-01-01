using System.Collections.Generic;
using UnityEngine;

namespace Managers
{
    public class ItemManager : MonoBehaviour
    {
        // private readonly GameObject[][] allItems = new GameObject[3][];
        // [SerializeField] private GameObject[] regularPool;
        // [SerializeField] private GameObject[] shopPool;
        // [SerializeField] private GameObject[] demonPool;
        // [SerializeField] private Transform itemSpawnPosition;
        // public ItemPool debugPool;
        //
        // private void Awake()
        // {
        //     allItems[(int)ItemPool.RegularPool] = regularPool;
        //     allItems[(int)ItemPool.ShopPool] = shopPool;
        //     allItems[(int)ItemPool.DemonPool] = demonPool;
        //
        //     GameEventManager.Instance.itemEvents.OnCreateItemFromPool += GetItemFromPool;
        // }
        //
        // private void GetItemFromPool(ItemPool itemPool)
        // {
        //     // Get item pool
        //     ref var pool = ref allItems[(int)itemPool];
        //     
        //     // Get item from pool
        //     var itemId = 0;
        //     
        //     // Try to get an item and if the item is null (it has been pulled previously) try again.
        //     do
        //     {
        //         itemId = Random.Range(0, pool.Length);
        //     } while (!pool[itemId]);
        //     
        //     Instantiate(pool[itemId], itemSpawnPosition.position, Quaternion.identity);
        //     
        //     // Set the item to null if it has been pulled unless it's the first item (default fallback)
        //     if (itemId != 0) pool[itemId] = null;
        // }
        //
        // public GameObject GetItem()
        // {
        //     // Get item pool
        //     var poolId = Random.Range(0, allItems.Length);
        //     ref var pool = ref allItems[poolId];
        //     
        //     // Get item from pool
        //     var itemId = Random.Range(0, pool.Length);
        //     return pool[itemId] ? pool[itemId] : pool[0];
        // }
        /// <summary>
        /// The GameObject arrays are used to add prefabs from the editor. Later, during Awake, the prefabs in these arrays are added to a dictionary in itemId, GameObject pairs.
        /// </summary>
        private readonly Dictionary<ushort, GameObject>[] allItems = new Dictionary<ushort, GameObject>[3];
        [SerializeField] private GameObject[] regularPoolEditor;
        private Dictionary<ushort, GameObject> regularPool;
        [SerializeField] private GameObject[] shopPoolEditor;
        private Dictionary<ushort, GameObject> shopPool;
        [SerializeField] private GameObject[] demonPoolEditor;
        private Dictionary<ushort, GameObject> demonPool;
        [SerializeField] private Transform itemSpawnPosition;

        private void Awake()
        {
            // FillDictionary(ref regularPool, ref regularPoolEditor);
        }

        // private void FillDictionary(ref Dictionary<ushort, GameObject> dictionaryItemPool, ref GameObject[] arrayItemPool)
        // {
        //     for (var i = 0; i < arrayItemPool.Length; i++)
        //     {
        //         var itemId = arrayItemPool[i].GetComponent<Item.Item>().ItemInformation.itemId;
        //         dictionaryItemPool.Add(5, arrayItemPool[i]);
        //     }
        // }
    }
}
