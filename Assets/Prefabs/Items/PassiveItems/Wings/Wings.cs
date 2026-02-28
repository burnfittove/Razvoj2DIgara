using Item.PassiveItem;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Prefabs.Items.PassiveItems.Wings
{
    public class Wings : PassiveItem
    {
        protected override void OnItemPickedUp()
        {
            SceneManager.sceneLoaded += (_, _) => ExcludePlayerFromHoleColliders();
            ChangeSpeed(itemInformation.speedDelta);
            base.OnItemPickedUp();
        }

        private void ExcludePlayerFromHoleColliders()
        {
            var obj = GameObject.FindGameObjectWithTag("Hole");
            if (!obj) return;
            obj.GetComponent<Collider2D>().enabled = false;
        }
    }
}
