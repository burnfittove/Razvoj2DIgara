using System;
using Events;
using PlayerScripts;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

namespace Managers
{
    public class RoomManager : MonoBehaviour
    {
        private int enemiesInTheRoom;
        private const float BasePennyChance = 20;
        private const float BaseItemChance = 500;
        private const float ChanceModifier = 1.2f; // The larger this value, the more the player's luck will change the chance of getting a reward (see GetModifiedChance())
        [SerializeField] private Player player;
        [SerializeField] private Transform spawnPosition;
        // Regular rooms
        [Header("Regular Rooms")]
        [SerializeField] private string regularRoomName = "RegularRoom";
        [SerializeField] private int regularRoomAmount = 2;
        // Item rooms
        [Header("Item Rooms")]
        [SerializeField] private string itemRoomName = "ItemRoom";
        [SerializeField] private int itemRoomAmount = 1;
        [SerializeField] private int itemRoomFrequency = 5; // Every nth room will be an item room
        private int roomsUntilItemRoom;
        public Scene scene;
        
        private void Awake()
        {
            // Get component references
            if (!player) GameObject.FindGameObjectWithTag("Player").TryGetComponent(out player);
            
            // Subscribe to events
            SceneManager.sceneLoaded += (_, _) =>
            {
                GetAllEnemiesInRoom();
                var spawnPos = GameObject.FindGameObjectWithTag("Spawner").transform;
                if (spawnPos) spawnPosition = spawnPos;
            };
            GameEventManager.Instance.roomEvents.OnEnemyDeath += DecreaseOnEnemyCount;
            GameEventManager.Instance.roomEvents.OnRoomCleared += SpawnReward;
            GameEventManager.Instance.roomEvents.OnChangeRoom += ChangeRoom;
            
            // Set variables
            roomsUntilItemRoom = itemRoomFrequency;
        }

        private void Start()
        {
            // Clear start room to give a potential reward in the start room and allow the player to continue
            GameEventManager.Instance.roomEvents.RoomCleared(true);
        }

        private void DecreaseOnEnemyCount()
        {
            // Decrease the enemy count in the room
            enemiesInTheRoom--;
            
            // If there are no more enemies in the room, mark the room as cleared
            if (enemiesInTheRoom <= 0) GameEventManager.Instance.roomEvents.RoomCleared(true);
        }

        private void GetAllEnemiesInRoom()
        {
            // Get the amount of enemies in the room
            enemiesInTheRoom = GameObject.FindGameObjectsWithTag("Enemy").Length;
            
            if (enemiesInTheRoom == 0) GameEventManager.Instance.roomEvents.RoomCleared(false);
        }

        private void SpawnReward(bool createReward) // TODO: Move this function to a reward handout manager
        {
            // If the room doesn't give a reward, return
            if (!createReward) return;
            
            // Check for item
            var chance = Random.Range(BaseItemChance, GetModifiedChance(BaseItemChance));
            if (chance <= PlayerInfo.Instance.Luck.Value)
            {
                // Get a copy of the item
                var obj = GameEventManager.Instance.itemEvents.GetItemFromPool(ItemPool.RegularPool);
                // If the pool is empty, do nothing
                if (!obj) return;
                // Set its position and activate it
                obj.transform.position = spawnPosition.position;
                obj.SetActive(true);
                return;
            }
            
            // Check for penny
            SetCurrencyPrefab(GameEventManager.Instance.itemEvents.GetPenny, BasePennyChance);
        }

        private void SetCurrencyPrefab(Func<GameObject> getCurrency, float baseChance)
        {
            var chance = Random.Range(baseChance, GetModifiedChance(baseChance));
            if (!(chance <= PlayerInfo.Instance.Luck.Value)) return;
            // Get a copy of the item
            var obj = getCurrency();
            // Set its position and activate it
            obj.transform.position = spawnPosition.position;
            obj.SetActive(true);
        }

        private float GetModifiedChance(float baseChance)
        {
            return baseChance + PlayerInfo.Instance.Luck.Value / 1.1f;
        }

        private void ChangeRoom()
        {
            // Change the scene to an ItemRoom
            if (roomsUntilItemRoom <= 0)
            {
                roomsUntilItemRoom = itemRoomFrequency;
                var itemRoomSuffix = Random.Range(0, itemRoomAmount);
                SceneManager.LoadScene($"{itemRoomName}{itemRoomSuffix}");
                return;
            }
            
            // Change the scene to a RegularRoom
            var regRoomSuffix = Random.Range(0, regularRoomAmount);
            SceneManager.LoadSceneAsync($"{regularRoomName}{regRoomSuffix}");
            roomsUntilItemRoom--;
        }
    }
}
