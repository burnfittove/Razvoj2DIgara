using Events;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Prefabs.Items.ActiveItem.Incantation
{
    public class Incantation : Item.ActiveItem.ActiveItem
    {
        private bool addedDamage;

        protected override void OnItemPickedUp()
        {
            base.OnItemPickedUp();
            SceneManager.sceneLoaded += (_, _) => RemoveAddedDamage();
        }

        public override void UseActiveItem()
        {
            base.UseActiveItem();
            GameEventManager.Instance.attributeUpdateEvents.DamageChange(itemInformation.damageDelta);
            addedDamage = true;
        }

        private void RemoveAddedDamage()
        {
            if (!addedDamage) return;
            GameEventManager.Instance.attributeUpdateEvents.DamageChange(-itemInformation.damageDelta);
            addedDamage = false;
        }
    }
}
