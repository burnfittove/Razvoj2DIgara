using UnityEngine;

namespace Item
{
    public class ItemInformationSo : ScriptableObject
    {
        [Header("Basic Information")]
        public string itemName;
        public string itemDescription;
        public byte itemQuality;
        public ushort itemId;
        public bool isPersistantPassive;
        public bool healAcquiredHealth;
        public int price;

        [Header("Base")] 
        public float maxHealthDelta;
        public float speedDelta;
        public float damageDelta;
        public float fireDelayDelta;
        public float rangeDelta;
        public float shotSpeedDelta;
        public float luckDelta;
        public float knockbackDelta;
        public float contactDamageDelta;
        
        [Header("Multipliers")] 
        public float speedMultiplierDelta;
        public float damageMultiplierDelta;
        public float fireDelayMultiplierDelta;
        public float rangeMultiplierDelta;
        public float luckMultiplierDelta;
    }
}