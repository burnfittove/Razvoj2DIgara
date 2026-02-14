using System;
using Events;
using JetBrains.Annotations;
using PlayerScripts;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Managers
{
    public class RoomManager : MonoBehaviour
    {
        private int enemiesInTheRoom;
        private const float basePennyChance = 20;
        private const float baseItemChance = 500;
        private const float chanceModifier = 1.2f; // The larger this value, the more the player's luck will change the chance of getting a reward (see GetModifiedChance())
        [SerializeField] private Player player;
        [SerializeField] private Transform spawnPosition;
        [SerializeField] private bool isClearedByDefault;
        
        private void Awake()
        {
            // Get component references
            if (!player) GameObject.FindGameObjectWithTag("Player").TryGetComponent(out player);
            
            // Get the amount of enemies in the room
            enemiesInTheRoom = GameObject.FindGameObjectsWithTag("Enemy").Length;
            
            // Subscribe to events
            GameEventManager.Instance.roomEvents.OnEnemyDeath += DecreaseOnEnemyCount;
            GameEventManager.Instance.roomEvents.OnRoomCleared += SpawnReward;
        }

        private void Start()
        {
            // If the room is cleared by default, run room cleared
            if (isClearedByDefault) GameEventManager.Instance.roomEvents.RoomCleared();
        }

        private void DecreaseOnEnemyCount()
        {
            // Decrease the enemy count in the room
            enemiesInTheRoom--;
            
            // If there are no more enemies in the room, mark the room as cleared
            if (enemiesInTheRoom <= 0) GameEventManager.Instance.roomEvents.RoomCleared();
        }

        private void SpawnReward()
        {
            // Check for item
            var chance = Random.Range(baseItemChance, GetModifiedChance(baseItemChance));
            if (chance <= player?.Luck.Value)
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
            SetCurrencyPrefab(GameEventManager.Instance.itemEvents.GetPenny, basePennyChance);
        }

        private void SetCurrencyPrefab(Func<GameObject> getCurrency, float baseChance)
        {
            var chance = Random.Range(baseChance, GetModifiedChance(baseChance));
            if (!(chance <= player?.Luck.Value)) return;
            // Get a copy of the item
            var obj = getCurrency();
            // Set its position and activate it
            obj.transform.position = spawnPosition.position;
            obj.SetActive(true);
        }

        private float GetModifiedChance(float baseChance)
        {
            return baseChance + player.Luck.Value / 1.1f;
        }
    }
}
