using Items.ItemEffects;

namespace Items.BlackAmulet
{
    public class BlackAmuletEffect : PassiveItemEffect
    {
        private void Awake()
        {
            ChangeDamage(itemInformation.damageDelta);
        }
    }
}
