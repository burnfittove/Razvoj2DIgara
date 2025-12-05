using Items.ItemEffects;

namespace Items.PassiveItems.BlackAmulet
{
    public class BlackAmuletEffect : PassiveItemEffect
    {
        protected override void Awake()
        {
            ChangeDamage(itemInformation.damageDelta);
        }
    }
}
