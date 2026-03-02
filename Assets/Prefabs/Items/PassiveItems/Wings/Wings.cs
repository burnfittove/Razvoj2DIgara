using Item.PassiveItem;
using PlayerScripts;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Prefabs.Items.PassiveItems.Wings
{
    public class Wings : PassiveItem
    {
        protected override void OnItemPickedUp()
        {
            PlayerInfo.Instance.canFly = true;
            ChangeSpeed(itemInformation.speedDelta);
            base.OnItemPickedUp();
        }
    }
}
