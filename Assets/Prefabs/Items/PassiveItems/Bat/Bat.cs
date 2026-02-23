using Item.PassiveItem;
using UnityEngine;

namespace Prefabs.Items.PassiveItems.Bat
{
    public class Bat : PassiveItem
    {
        [SerializeField] private GameObject batPrefab;

        protected override void OnItemPickedUp()
        {
            Instantiate(batPrefab, player.transform.position, player.transform.rotation, player.transform);
            base.OnItemPickedUp();
        }
    }
}
