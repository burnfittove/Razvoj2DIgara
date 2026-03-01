using System;
using UnityEngine;

namespace Prefabs.Items.PassiveItems.Familiar
{
    public class Familiar : MonoBehaviour
    {
        [SerializeField] private float rotationSpeed;
        [SerializeField] private Transform rotationPoint;
 
        protected virtual void Update()
        {
            transform.RotateAround(rotationPoint.position, Vector3.forward, rotationSpeed * Time.deltaTime);
        }
    }
}