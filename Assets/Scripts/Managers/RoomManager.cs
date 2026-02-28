using System;
using Currencies.Money;
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
        private const float BasePennyChance = 10;
        private const float BaseNickelChance = 30;
        private const float BaseDimeChance = 100;
        private const float BaseQuarterChance = 200;
        private const float BaseItemChance = 750;
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
        // Shop
        [Header("Shops")]
        [SerializeField] private string shopName = "Shop";
        [SerializeField] private int shopAmount = 1;
        [SerializeField] private int shopFrequency = 15; // Every nth room will be an item room
        private int roomsUntilShop;
        // Rewards
        private GameObject reward;
        
        private void Awake()
        {
            // Get component references
            if (!player) GameObject.FindGameObjectWithTag("Player").TryGetComponent(out player);
            
            // Subscribe to events
            SceneManager.sceneLoaded += (_, _) =>
            {
                // Set the item spawning position
                var spawnPos = GameObject.FindGameObjectWithTag("Spawner").transform;
                if (spawnPos) spawnPosition = spawnPos;
                
                // Get all the enemies in the room
                GetAllEnemiesInRoom();
            };
            GameEventManager.Instance.roomEvents.OnEnemyDeath += DecreaseOnEnemyCount;
            GameEventManager.Instance.roomEvents.OnRoomCleared += ShowReward;
            GameEventManager.Instance.roomEvents.OnChangeRoom += ChangeRoom;
            
            // Set variables
            roomsUntilItemRoom = itemRoomFrequency;
            roomsUntilShop = shopFrequency;
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
            // Chance the scene to a shop
            if (roomsUntilShop <= 0)
            {
                roomsUntilShop = shopFrequency;
                roomsUntilItemRoom = itemRoomFrequency; // Since shops override item rooms, it needs to reset this value
                var itemRoomSuffix = Random.Range(0, shopAmount);
                SceneManager.LoadSceneAsync($"{shopName}{itemRoomSuffix}");
                return;
            }
            
            // Change the scene to an ItemRoom
            if (roomsUntilItemRoom <= 0)
            {
                roomsUntilItemRoom = itemRoomFrequency;
                var itemRoomSuffix = Random.Range(0, itemRoomAmount);
                SceneManager.LoadSceneAsync($"{itemRoomName}{itemRoomSuffix}");
                return;
            }
            
            // Change the scene to a RegularRoom
            var regRoomSuffix = Random.Range(0, regularRoomAmount);
            SceneManager.LoadSceneAsync($"{regularRoomName}{regRoomSuffix}");
            roomsUntilItemRoom--;
            roomsUntilShop--;
        }

        private void ShowReward()
        {
            // If a reward was not chosen, return
            if (!reward) return;
            
            // Otherwise, reveal the reward
            reward.transform.position = spawnPosition.position;
            reward.SetActive(true);
        }
    }
}
