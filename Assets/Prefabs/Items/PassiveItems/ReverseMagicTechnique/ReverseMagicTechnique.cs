using Item.PassiveItem;
using PlayerScripts;
using UnityEngine;

namespace Prefabs.Items.PassiveItems.ReverseMagicTechnique
{
    public class ReverseMagicTechnique : PassiveItem
    {
        protected override void OnItemPickedUp()
        {
            ChangeMaxHealth(itemInformation.maxHealthDelta);
            base.OnItemPickedUp();
        }

        protected override void RoomStartEffect()
        {
            if (Random.Range(0, 11) <= PlayerInfo.Instance.Luck.Value) ChangeHealth(5);
        }
    }
}
