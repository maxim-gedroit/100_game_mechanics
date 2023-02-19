using UnityEngine;

namespace RedBarrels.Scripts
{
    public class RedBarrel : MonoBehaviour
    {
        public float Radius = 10f;
        public float Force = 500f;
        
        private void OnCollisionEnter(Collision collision)
        {
            if (collision.collider.tag == "Map")
                return;
            
            Explode();
        }

        public void Explode()
        {
            Collider[] overlappedColliders = Physics.OverlapSphere(transform.position, Radius);
            for (int i = 0; i < overlappedColliders.Length; i++)
            {
                Rigidbody rigidbody = overlappedColliders[i].attachedRigidbody;
                if (rigidbody)
                {
                    rigidbody.AddExplosionForce(Force,transform.position,Radius);
                }
            }
            Destroy(gameObject);
        }
    }
}
