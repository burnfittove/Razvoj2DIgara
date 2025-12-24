using UnityEngine;

namespace Enemies
{
    
    [CreateAssetMenu(menuName = "ScriptableObjects/EnemyInformation", fileName = "EnemyInformationSO", order = 0)]
    public class EnemyInformationSO : ScriptableObject
    {
        public string enemyName;
        public byte enemyId;
        public float health;
        public float speed;
        public float acceleration = 10;
        public float damage;
        public float contactDamage;
        public float fireDelay;
        public float range;
        public float shotSpeed;
    }
}
