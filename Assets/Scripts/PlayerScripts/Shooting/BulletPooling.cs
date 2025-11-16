using System.Collections.Generic;
using UnityEngine;

namespace PlayerScripts.Shooting
{
    public class BulletPooling : MonoBehaviour
    {
        public static BulletPooling SharedInstance;
        public List<Bullet> pooledObjects;
        public GameObject objectToPool;
        public int amountToPool;

        private void Awake()
        {
            SharedInstance = this;
        }

        private void Start()
        {
            pooledObjects = new List<Bullet>();
            for (var i = 0; i < amountToPool; i++)
            {
                var tmp = Instantiate(objectToPool);
                tmp.SetActive(false);
                pooledObjects.Add(tmp.GetComponent<Bullet>());
            }
        }

        // Return inactive Bullets
        public Bullet GetPooledObject()
        {
            for (var i = 0; i < amountToPool; i++)
            {
                if (!pooledObjects[i].gameObject.activeInHierarchy)
                {
                    return pooledObjects[i];
                }
            }
            return null;
        }
    }
}
