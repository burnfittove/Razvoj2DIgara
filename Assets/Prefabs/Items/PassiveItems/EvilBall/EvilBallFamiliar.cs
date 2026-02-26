using Enemies;
using UnityEngine;

namespace Prefabs.Items.PassiveItems.EvilBall
{
    public class EvilBallFamiliar : MonoBehaviour
    {
        [SerializeField] private float contactDamage;
        private void OnTriggerStay2D(Collider2D other)
        {
            if (!other.CompareTag("Enemy")) return;
            other.GetComponent<Enemy>()?.TakeContactDamage(contactDamage);
        }
    }
}
