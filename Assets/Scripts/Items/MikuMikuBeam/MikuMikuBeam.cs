using Events;
using Items;

public class MikuMikuBeam : Item
{
    public override void OnItemPickup()
    {
        GameEventManager.Instance.PassiveItemEvents.PassiveItemAcquired(this);
    }
}
