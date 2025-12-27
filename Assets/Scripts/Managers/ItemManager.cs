using UnityEngine;
using Random = UnityEngine.Random;

namespace Managers
{
    public class ItemManager : MonoBehaviour
    {
        private readonly GameObject[][] allItems = new GameObject[3][];
        [SerializeField] private GameObject[] regularPool;
        [SerializeField] private GameObject[] shopPool;
        [SerializeField] private GameObject[] demonPool;

        private void Awake()
        {
            allItems[(int)ItemPool.RegularPool] = regularPool;
            allItems[(int)ItemPool.ShopPool] = shopPool;
            allItems[(int)ItemPool.DemonPool] = demonPool;
        }

        public GameObject GetItem(ItemPool itemPool, int itemId)
        {
            return allItems[(int)itemPool][itemId];
        }

        public GameObject GetItem(ItemPool itemPool)
        {
            ref var pool = ref allItems[(int)itemPool];
            var itemId = Random.Range(0, pool.Length);
            return pool[itemId] ? pool[itemId] : pool[0];
        }
    }
}
