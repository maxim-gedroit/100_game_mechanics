using UnityEngine;

public class ObjectController : MonoBehaviour
{
    private Rigidbody _rigidbody;
    [SerializeField] private float _force;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        _rigidbody.AddForce(Vector3.forward * _force);
    }
}