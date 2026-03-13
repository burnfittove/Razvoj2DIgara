using System.Collections.Generic;
using System.IO;
using System.Linq;
using Item.ActiveItem;
using Managers;
using PlayerScripts;
using UnityEngine;
using Attribute = PlayerScripts.Attribute;

namespace Saving
{
    public class SaveDataManager
    {
        private readonly SaveDataMapper mapper = new();
        private GameData gameData;
        private readonly Player player = GameObject.FindWithTag("Player")?.GetComponent<Player>();

        private GameData GetAllData()
        {
            var itemIds = (from Transform child in player.transform where child.CompareTag("Item") select child.GetComponent<Item.Item>().itemInformation.itemId).ToList();
            
            return new GameData
            {
                maxHealth = PlayerInfo.Instance.MaxHealth,
                health = PlayerInfo.Instance.Health,
                speed = PlayerInfo.Instance.Speed,
                damage = PlayerInfo.Instance.Damage,
                fireDelay = PlayerInfo.Instance.FireDelay,
                range = PlayerInfo.Instance.Range,
                shotSpeed = PlayerInfo.Instance.ShotSpeed,
                luck = PlayerInfo.Instance.Luck,
                knockbackStrength = PlayerInfo.Instance.KnockbackStrength,
                contactDamage = PlayerInfo.Instance.ContactDamage,
                invincibilityDuration = PlayerInfo.Instance.InvincibilityDuration,
                money = PlayerInfo.Instance.Money,
                souls = PlayerInfo.Instance.Souls,
                canFly = PlayerInfo.Instance.canFly,
                itemIds = itemIds,
                currentRoomCount = RoomManager.Instance.roomCounter,
                activeItemCharge = PlayerInfo.Instance.ActiveItem is null ? 0 : PlayerInfo.Instance.ActiveItem.GetComponent<ActiveItem>().currentCharge
            };
        }

        public void SaveGame()
        {
            gameData = GetAllData();
            mapper.SaveGame(gameData);
        }

        public GameData LoadGame()
        {
            var data = mapper.LoadGame();
            if (data == null) Debug.LogWarning("Error when loading data, mapper returned null");
            return data;
        }

        public bool SaveFileExists()
        {
            return File.Exists(mapper.GetSaveFilePath());
        }
    }
}