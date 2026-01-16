using Events;

namespace Prefabs.Items.ActiveItem.PieceOfPaper
{
    public class PieceOfPaper : Item.ActiveItem.ActiveItem
    {
        public override void UseActiveItem()
        {
            GameEventManager.Instance.attributeUpdateEvents.HealthChange(itemInformation.maxHealthDelta);
            base.UseActiveItem();
        }
    }
}
