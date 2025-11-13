using UnityEngine;

namespace Items
{
    [CreateAssetMenu(menuName = "Items/ItemInformationSO", fileName = "ItemInformationSO", order = 0)]
    public class ItemInformationSO : ScriptableObject
    {
        public string itemName;
        public string itemDescription;
        public byte itemQuality;
        public byte itemId;
        public float damageDelta;
        public float damageMultiplierDelta;
        public float healthDelta;
        public float speedDelta;
        public float bulletLifetimeDelta;
        public float fireDelayDelta;
        public float fireRateMultiplierDelta;
    }
}
