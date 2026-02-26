using UnityEngine;
using UnityEngine.Serialization;

namespace Item.PassiveItem
{
    public class FamiliarPassive : PassiveItem
    {
        [SerializeField] private GameObject familiarPrefab;

        protected override void OnItemPickedUp()
        {
            Instantiate(familiarPrefab, player.transform.position, player.transform.rotation, player.transform);
            base.OnItemPickedUp();
        }
    }
}
