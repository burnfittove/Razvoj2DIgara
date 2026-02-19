using Item.PassiveItem;

namespace Prefabs.Items.PassiveItems.Fangs
{
    public class Fangs : PassiveItem
    {
        protected override void OnItemPickedUp()
        {
            ChangeContactDamage(itemInformation.contactDamageDelta);
            ChangeDamage(itemInformation.damageDelta);
            base.OnItemPickedUp();
        }
    }
}
