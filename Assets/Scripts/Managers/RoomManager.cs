using System;
using Events;
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
        
        private void Awake()
        {
            // Get the amount of enemies in the room
            enemiesInTheRoom = GameObject.FindGameObjectsWithTag("Enemy").Length;
            
            // Subscribe to events
            GameEventManager.Instance.roomEvents.EnemyDeath += DecreaseEnemyCount;
            GameEventManager.Instance.roomEvents.EnemyDeath += SpawnReward;
        }

        private void DecreaseEnemyCount()
        {
            enemiesInTheRoom--;
        }

        private void SpawnReward()
        {
            if (enemiesInTheRoom > 0) return;
            
            // Check for item
            var chance = Random.Range(baseItemChance, GetModifiedChance(baseItemChance));
            if (chance <= player.Luck.Value)
            {
                // Get a copy of the item
                var obj = GameEventManager.Instance.itemEvents.GetItemFromPool(ItemPool.RegularPool);
                // Set its position and activate it
                obj.transform.position = spawnPosition.position;
                obj.SetActive(true);
                return;
            }
            
            // Check for penny
            chance = Random.Range(basePennyChance, GetModifiedChance(basePennyChance));
            if (chance <= player.Luck.Value)
            {
                // Get a copy of the item
                var obj = GameEventManager.Instance.itemEvents.GetPenny();
                // Set its position and activate it
                obj.transform.position = spawnPosition.position;
                obj.SetActive(true);
                return;
            }
        }

        private float GetModifiedChance(float baseChance)
        {
            return baseChance + player.Luck.Value / 1.1f;
        }
    }
}
