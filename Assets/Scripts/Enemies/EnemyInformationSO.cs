using UnityEngine;
using UnityEngine.Serialization;

namespace Enemies
{
    
    [CreateAssetMenu(menuName = "ScriptableObjects/EnemyInformation", fileName = "EnemyInformationSO", order = 0)]
    public class EnemyInformationSo : ScriptableObject
    {
        public string enemyName;
        public float health;
        public float speed;
        public float acceleration = 10;
        public float damage;
        public float contactDamage;
        public float fireDelay;
        public float range;
        public float sightRange = 10;
        public float shotSpeed;
        public float invincibilityDuration = 0.1f;
        public int baseMaxSoulSpawnChance = 10;
        public int baseMaxMoneySpawnChance = 5;
        
    }
}
