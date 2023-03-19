using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class PlayerBox : MonoBehaviour
{
    [SerializeField] private Transform _camera;
    public Vector3 CameraOffset;
    public float force;
    private Rigidbody _rigidbody;
    private Vector3 _startPoint;
    [SerializeField] private TMP_Text _label;
    

    private void Awake()
    {
        Physics.defaultContactOffset = 0.0001f;
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.maxAngularVelocity = 100f;
    }

    private void Start()
    {
        _startPoint = transform.position;
        StartCoroutine(ChangeForce());
    }

    private IEnumerator ChangeForce()
    {
        while (force < 100)
        {
            force += 3;
            yield return new WaitForSeconds(1);
        }
    }

    private void Update()
    {

        if (Input.GetKey(KeyCode.A))
        {
            _rigidbody.AddForce(Vector3.left * force/8);
        }
        
        if (Input.GetKey(KeyCode.D))
        {
            _rigidbody.AddForce(Vector3.right * force/8);
        }
        
        
    }

    private void FixedUpdate()
    {
        if (transform.position.z >= 450f)
        {
            transform.position = new Vector3(transform.position.x,transform.position.y,_startPoint.z);
        }
        _rigidbody.AddForce(Vector3.forward * force); 
        _label.text = Math.Round(_rigidbody.velocity.z,1).ToString();
    }

    private void LateUpdate()
    {
        _camera.transform.position = (transform.position + CameraOffset);
        _camera.LookAt(transform);
    }
}