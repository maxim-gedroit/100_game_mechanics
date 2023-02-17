using System;
using UnityEngine;

namespace HealthAsACurrency.Scripts
{
    public class Bullet : MonoBehaviour
    {
        private void Start()
        {
            Destroy(gameObject,3f);
        }
    }
}