using UnityEngine;

namespace Items
{
    [CreateAssetMenu(menuName = "ScriptableObjects/ItemInformation", fileName = "ItemInformationSO", order = 0)]
    public class ItemInformationSO : ScriptableObject
    {
        [Header("Item Info")]
        public Sprite itemSprite;
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
        public float fireDelayMultiplierDelta;
        public float rangeMultiplierDelta;
        public float luckMultiplierDelta;
        public float knockbackDelta;
        public float contactDamageDelta;
        [Header("Other")] 
        public bool healAcquiredHealth;
        public int price;
    }
}
