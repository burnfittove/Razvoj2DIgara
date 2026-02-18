using UnityEngine;

namespace PlayerScripts
{
    [CreateAssetMenu(menuName = "ScriptableObjects/PlayerInformation", fileName = "PlayerInformationSO", order = 2)]
    public class PlayerInformationSo : ScriptableObject
    {
        [Header("Character Info")] 
        public string characterName;
        public byte characterId;
        [Header("Starting Attributes")] 
        public float health;
        public float speed;
        public float damage;
        public float fireDelay;
        public float range;
        public float shotSpeed;
        public float luck = 1;
        [Header("Hidden Starting Attributes")]
        public float speedMultiplier = 1;
        public float damageMultiplier = 1;
        public float fireDelayMultiplier = 1;
        public float rangeMultiplier = 1;
        public float luckMultiplier = 1;
        public float knockbackStrength = 1;
        public float contactDamage = 0;
        public float invincibilityDuration = 1.2f;
        [Header("Constraints")] 
        public float maxSpeed = 50;
        public float maxHealth = 100;
        public float minValue = .2f;
        public float minMultiplier = .1f;
        public float maxMultiplier = 2;
    }
}
