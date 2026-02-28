using Enemies;
using UnityEngine;

namespace Prefabs.Items.ActiveItem.Gas
{
    public class Gas : Item.ActiveItem.ActiveItem
    {
        public override void UseActiveItem()
        {
            base.UseActiveItem();

            var objs = FindObjectsByType<Enemy>((FindObjectsSortMode)FindObjectsInactive.Exclude);

            foreach (var obj in objs)
            {
                obj.TakeDamage(itemInformation.maxHealthDelta);
            }
            Debug.Log("Sooo... that just happened... MERP!");
        }
    }
}
