using UnityEngine;

namespace Items
{
    [CreateAssetMenu(menuName = "ScriptableObjects/ItemInformation", fileName = "ItemInformationSO", order = 0)]
    public class ItemInformationSO : ScriptableObject
    {
        [Header("Item Info")]
        public string itemName;
        public string itemDescription;
        public byte itemQuality;
        public byte itemId;
        [Header("Visible Attributes")]
        public float maxHealthDelta;
        public float speedDelta;
        public float damageDelta;
        public float fireDelayDelta;
        public float rangeDelta;
        public float shotSpeedDelta;
        public float luckDelta;
        [Header("Hidden Attributes")]
        public float speedMultiplierDelta;
        public float damageMultiplierDelta;
        public float fireRateMultiplierDelta;
        public float rangeMultiplierDelta;
        public float luckMultiplierDelta;
        public float knockbackDelta;
        public float contactDamageDelta;
        public bool healAcquiredHealth;
    }
}
