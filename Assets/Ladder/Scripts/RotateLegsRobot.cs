using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class RotateLegsRobot : MonoBehaviour
{
    private Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    { 
         _rigidbody.AddTorque(transform.right * 80f);
    }
}
