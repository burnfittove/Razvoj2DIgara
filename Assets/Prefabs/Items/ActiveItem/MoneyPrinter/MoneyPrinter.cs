using PlayerScripts;
using UnityEngine;

namespace Prefabs.Items.ActiveItem.MoneyPrinter
{
    public class MoneyPrinter : Item.ActiveItem.ActiveItem
    {
        [SerializeField] private GameObject moneyPrefab;
        public override void UseActiveItem()
        {
            if (!moneyPrefab) Debug.LogWarning($"{nameof(moneyPrefab)} has not been set.");
            var chance = Random.Range(0, 10);
            if (!(chance > PlayerInfo.Instance.Luck.Value)) Instantiate(moneyPrefab,
                (Vector2)player.transform.position +
                new Vector2(Random.Range(1.2f, 1.8f), Random.Range(1.2f, 1.8f)), Quaternion.identity);
            base.UseActiveItem();
        }
    }
}
