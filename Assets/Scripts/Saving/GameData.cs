using System;
using System.Collections.Generic;
using GUI.Attributes;
using Item.PassiveItem;
using PlayerScripts;
using UnityEngine;
using Attribute = PlayerScripts.Attribute;

namespace Saving
{
    [Serializable]
    public class GameData
    {
        // Player attributes
        public Attribute maxHealth;
        public Attribute health;
        public Attribute speed;
        public Attribute damage;
        public Attribute fireDelay;
        public Attribute range;
        public Attribute shotSpeed;
        public Attribute luck;
        public Attribute knockbackStrength;
        public Attribute contactDamage;
        public Attribute invincibilityDuration;
        public Attribute money;
        public Attribute souls;
        public bool canFly;
    }
}
