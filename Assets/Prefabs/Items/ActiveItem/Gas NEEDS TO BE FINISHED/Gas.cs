using System.Collections.Generic;
using Events;

namespace Prefabs.Items.ActiveItem.Gas
{
    public class Gas : Item.ActiveItem.ActiveItem
    {
        // private List<IDamageable> damageables = new ();
        public override void UseActiveItem()
        {
            base.UseActiveItem();
            // GetComponents(damageables);
            //
            // foreach (var damageable in damageables)
            // {
            //     if (damageable)
            // }
        }
        
        protected override void OnItemPickedUp()
        {
            GameEventManager.Instance.roomEvents.OnRoomCleared += IncreaseCharge;
            base.OnItemPickedUp();
        }
    }
}
