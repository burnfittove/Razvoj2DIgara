using System;
using Currencies.Money;
using Events;
using PlayerScripts;
using Saving;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

namespace Managers
{
    public class RoomManager : MonoBehaviour, ILoadable
    {
        [DoNotSerialize] public static RoomManager Instance { get; private set; }
        // Per room stats
        private int enemiesInTheRoom;
        private const float BasePennyChance = 10;
        private const float BaseNickelChance = 30;
        private const float BaseDimeChance = 100;
        private const float BaseQuarterChance = 200;
        private const float BaseItemChance = 750;
        private const float ChanceModifier = 1.2f; // The larger this value, the more the player's luck will change the chance of getting a reward (see GetModifiedChance())
        [SerializeField] private Player player;
        [SerializeField] private Transform spawnPosition;
        // Global settings
        // Regular rooms
        [Header("Regular Rooms")]
        [SerializeField] private string regularRoomName = "RegularRoom";
        [SerializeField] private int regularRoomAmount = 2;
        // Item rooms
        [Header("Item Rooms")]
        [SerializeField] private string itemRoomName = "ItemRoom";
        [SerializeField] private int itemRoomAmount = 1;
        [SerializeField] private int itemRoomFrequency = 5; // Every nth room will be an item room, shops take precedent
        // Shop
        [Header("Shops")]
        [SerializeField] private string shopName = "Shop";
        [SerializeField] private int shopAmount = 1;
        [SerializeField] private int shopFrequency = 15; // Every nth room will be an item room
        public int roomCounter;
        public int displayableRoomCounter;
        public string finalRoom = "finalRoom";
        public int totalRooms = 125;
        // Rewards
        private GameObject reward;
        public string deathScene;
        
        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);
                return;
            }
            Instance = this;
            
            // Get component references
            if (!player) GameObject.FindGameObjectWithTag("Player").TryGetComponent(out player);
            
            // Subscribe to events
            SceneManager.sceneLoaded += (_, _) =>
            {
                // Set the item spawning position
                var spawnPos = GameObject.FindGameObjectWithTag("Spawner")?.transform;
                if (spawnPos) spawnPosition = spawnPos;
                
                // Get all the enemies in the room
                GetAllEnemiesInRoom();
                
                // Disable Hole colliders if the player can fly
                ExcludePlayerFromHoleColliders();
            };
            GameEventManager.Instance.roomEvents.OnEnemyDeath += DecreaseOnEnemyCount;
            GameEventManager.Instance.roomEvents.OnRoomCleared += ShowReward;
            GameEventManager.Instance.roomEvents.OnChangeRoom += ChangeRoom;
        }

        private void Start()
        {
            // Clear start room to give a potential reward in the start room and allow the player to continue
            GameEventManager.Instance.roomEvents.RoomCleared();
        }

        private void DecreaseOnEnemyCount()
        {
            // Decrease the enemy count in the room
            enemiesInTheRoom--;
            
            // If there are no more enemies in the room, mark the room as cleared
            if (enemiesInTheRoom <= 0) GameEventManager.Instance.roomEvents.RoomCleared();
        }

        private void GetAllEnemiesInRoom()
        {
            // Get the amount of enemies in the room
            enemiesInTheRoom = GameObject.FindGameObjectsWithTag("Enemy").Length;
            
            // If there are no enemies, mark the room as cleared and return
            if (enemiesInTheRoom == 0)
            {
                GameEventManager.Instance.roomEvents.RoomCleared();
                return;
            }
            
            // Get a reward
            CreateReward();
        }

        private void CreateReward()
        {
            // Check for item
            var chance = Random.Range(BaseItemChance, GetModifiedChance(BaseItemChance));
            if (chance <= PlayerInfo.Instance.Luck.value)
            {
                // Get a copy of the item
                reward = RewardManager.Instance.GetRewardItem(ItemPool.RewardPool);
                return;
            }
            
            // Check for quarter, then dime, the nickel, then penny
            // Quarter
            SetMoneyReward(MoneyValue.Quarter, BaseQuarterChance);
            // Dime
            SetMoneyReward(MoneyValue.Dime, BaseDimeChance);
            // Nickel
            SetMoneyReward(MoneyValue.Nickel, BaseNickelChance);
            // Penny
            SetMoneyReward(MoneyValue.Penny, BasePennyChance);
            
        }

        private void SetMoneyReward(MoneyValue moneyType, float baseChance)
        {
            // If the reward has already been decided, return
            if (reward) return;
            var chance = Random.Range(baseChance, GetModifiedChance(baseChance));
            if (chance > PlayerInfo.Instance.Luck.value) return;
            // Get a copy of the item
            reward = RewardManager.Instance.GetRewardMoney(moneyType);
        }

        private float GetModifiedChance(float baseChance)
        {
            return baseChance + PlayerInfo.Instance.Luck.value / ChanceModifier;
        }

        private void ChangeRoom()
        {
            if (roomCounter == totalRooms)
            {
                SceneManager.LoadSceneAsync(finalRoom);
                return;
            }
            
            if (roomCounter == 0)
            {
                LoadRoomType(regularRoomName, regularRoomAmount);
                displayableRoomCounter++;
                GameEventManager.Instance.roomEvents.RoomCounterDisplay(displayableRoomCounter);
                return;
            }
            
            // Chance the scene to a shop
            if (roomCounter % shopFrequency == 0)
            {
                LoadRoomType(shopName, shopAmount);
                GameEventManager.Instance.audioEvents.PlayShopMusic();
                return;
            }
            
            // Change the scene to an ItemRoom
            if (roomCounter % itemRoomFrequency == 0)
            {
                LoadRoomType(itemRoomName, itemRoomAmount);
                return;
            }
            
            // Change the scene to a RegularRoom
            LoadRoomType(regularRoomName, regularRoomAmount);
            displayableRoomCounter++;
            GameEventManager.Instance.roomEvents.RoomCounterDisplay(displayableRoomCounter);
            GameEventManager.Instance.audioEvents.PlayBattleMusic();
        }

        private void LoadRoomType(string roomType, int roomAmount)
        {
            roomCounter++;
            var roomSuffix = Random.Range(0, roomAmount);
            SceneManager.LoadSceneAsync($"{roomType}{roomSuffix}");
        }

        private void ShowReward()
        {
            // If a reward was not chosen, return
            if (!reward) return;
            
            // Otherwise, reveal the reward
            reward.transform.position = spawnPosition.position;
            reward.SetActive(true);
        }

        public void LoadData(GameData gameData)
        {
            roomCounter = gameData.currentRoomCount;
            displayableRoomCounter = gameData.currentDisplayableRoomCount;
            GameEventManager.Instance.roomEvents.RoomCounterDisplay(displayableRoomCounter);
        }
        
        
        private void ExcludePlayerFromHoleColliders()
        {
            if (!PlayerInfo.Instance.canFly) return;
            var obj = GameObject.FindGameObjectWithTag("Hole");
            if (!obj) return;
            obj.GetComponent<Collider2D>().enabled = false;
        }

        public void ChangeToDeathScene()
        {
            SceneManager.LoadSceneAsync(deathScene);
        }
    }
}
