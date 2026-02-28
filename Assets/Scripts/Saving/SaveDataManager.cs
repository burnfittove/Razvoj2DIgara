using System.Collections.Generic;
using PlayerScripts;
using UnityEngine;
using Attribute = PlayerScripts.Attribute;

namespace Saving
{
    public class SaveDataManager
    {
        private readonly SaveDataMapper mapper = new();
        private GameData gameData;

        private GameData GetAllData()
        {
            return new GameData
            {
                maxHealth =  PlayerInfo.Instance.MaxHealth,
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
                canFly = PlayerInfo.Instance.canFly
            };
        }

        public void SaveGame()
        {
            gameData = GetAllData();
            mapper.SaveGame(gameData);
        }
    }
}