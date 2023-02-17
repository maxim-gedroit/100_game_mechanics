using System.Collections;
using UnityEngine;

namespace HealthAsACurrency.Scripts
{
    public class Blaster : MonoBehaviour
    {
        public Transform SpawnTransform;
        public Transform TargetTransform;

        public float AngleInDegrees;

        float g = Physics.gravity.y;

        public GameObject Bullet;

        private void Start()
        {
            StartCoroutine(Fire());
        }

        private IEnumerator Fire()
        {
            while (true)
            {
                SpawnTransform.localEulerAngles = new Vector3(-AngleInDegrees, 0f, 0f);
                Shot();
                yield return new WaitForSeconds(0.5f);
            }
        }
        
        public void Shot()
        {
            Vector3 fromTo = TargetTransform.position - transform.position;
            Vector3 fromToXZ = new Vector3(fromTo.x, 0f, fromTo.z);

            transform.rotation = Quaternion.LookRotation(fromToXZ, Vector3.up);


            float x = fromToXZ.magnitude;
            float y = fromTo.y;

            float AngleInRadians = AngleInDegrees * Mathf.PI / 180;

            float v2 = (g * x * x) / (2f * (y - Mathf.Tan(AngleInRadians) * x) * Mathf.Pow(Mathf.Cos(AngleInRadians), 2));
            float v = Mathf.Sqrt(Mathf.Abs(v2));

            GameObject newBullet = Instantiate(Bullet, SpawnTransform.position, Quaternion.identity);
            newBullet.GetComponent<Rigidbody>().velocity = SpawnTransform.forward * v;
        }
    
    }
}