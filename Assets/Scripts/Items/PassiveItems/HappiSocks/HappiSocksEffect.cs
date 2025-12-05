using Items.ItemEffects;

namespace Items.PassiveItems.HappiSocks
{
    public class HappiSocksEffect : PassiveItemEffect
    {
        protected override void Awake()
        {
            ChangeSpeed(itemInformation.speedDelta);
        }
    }
}
