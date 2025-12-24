using Events;
using UnityEngine;

namespace Managers
{
    public class CurrencyManager : MonoBehaviour
    {
        private int MoneyAmount { get; set; }

        private void Awake()
        {
            GameEventManager.Instance.pickupEvents.OnCurrencyPickUp += IncreaseMoney;
        }

        private void IncreaseMoney(int amount)
        {
            MoneyAmount += amount;
            if (MoneyAmount < 0) MoneyAmount = 0;
        }
    }
}