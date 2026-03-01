using System;
using UnityEngine;
using UnityEngine.Serialization;

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
            Instantiate(itemInformation.familiarPrefab, player.transform.position, player.transform.rotation, transform);
        }
    }
}
