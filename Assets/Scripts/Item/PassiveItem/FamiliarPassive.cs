using System;
using UnityEngine;

namespace Item.PassiveItem
{
    [Serializable]
    public class FamiliarPassive : PassiveItem
    {
        protected override void OnItemPickedUp()
        {
            Initialize();
            base.OnItemPickedUp();
        }

        private void Initialize()
        {
            transform.position = player.transform.position;
            if (!itemInformation.familiarPrefab) return;
            Instantiate(itemInformation.familiarPrefab, player.transform.position, Quaternion.identity, transform);
        }
    }
}
