using UnityEngine;

namespace Item
{
    [CreateAssetMenu(menuName = "ScriptableObjects/ItemInformation", fileName = "ItemInformationSO", order = 0)]
    public class ItemInformationSo : ScriptableObject
    {
        [Header("Basic Information")]
        public int itemId;
        public string itemName;
        public string itemDescription;
        public byte itemQuality;
        public bool isPersistantPassive;
        public bool healAcquiredHealth;
        public int price;
        public int demonPrice;
        public int maxCharge;
        
        [Header("Attribute Changes")]
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