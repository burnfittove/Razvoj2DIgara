using UnityEngine;

namespace Items
{
    [CreateAssetMenu(menuName = "Items/ItemInformationSO", fileName = "ItemInformationSO", order = 0)]
    public class ItemInformationSO : ScriptableObject
    {
        [SerializeField] private float newDamage;
        [SerializeField] private float newHealth;
        [SerializeField] private float newSpeed;
        [SerializeField] private float newBulletLifetime;
        [SerializeField] private float newFireRate;
    }
}
