using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace Item
{
    [CreateAssetMenu(menuName = "ScriptableObjects/ItemInformation", fileName = "ItemInformationSO", order = 0)]
    [Serializable]
    public class ItemInformationSo : ScriptableObject
    {
        [Header("Basic Information")]
        public int itemId;
        public string itemName;
        public string itemDescription;
        public byte itemQuality;
        public bool isPersistantPassive;
        public int price;
        [FormerlySerializedAs("demonPrice")] public int vampirePrice;
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
        
        [Header("Familiars")]
        public GameObject familiarPrefab;
    }
}