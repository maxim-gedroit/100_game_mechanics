using System;
using TMPro;
using UnityEngine;

namespace HealthAsACurrency.Scripts
{
    [RequireComponent(typeof(CharacterController))]
    public class Player : MonoBehaviour
    {
        public int liveCount = 5;
        public float speed = 6.0f;
        public float jumpSpeed = 8.0f;
        public float rotateSpeed = 0.8f;
        public float gravity = 20.0f;
        
        private Vector3 _moveDirection = Vector3.zero;
        
       [SerializeField] private CharacterController _controller;
       [SerializeField] private Transform _playerCamera;
       [SerializeField] private TMP_Text _lifesLbl;
       private int LiveCount {
           get
           {
               return liveCount;
           }   
           set
           {
               liveCount = value;
               _lifesLbl.text = $"Life: {liveCount.ToString()}";
           }  
       }

       private void Awake()
       {
           _controller = GetComponent<CharacterController>();
       }

       void Start()
        {
            LiveCount = liveCount;
        }

        void Update()
        {
            Movement();
        }

        private void Movement()
        {
            transform.Rotate(0, Input.GetAxis("Mouse X") * rotateSpeed, 0);
            _playerCamera.Rotate(-Input.GetAxis("Mouse Y") * rotateSpeed, 0, 0);
            
            if (_playerCamera.localRotation.eulerAngles.y != 0)
            {
                _playerCamera.Rotate(Input.GetAxis("Mouse Y") * rotateSpeed, 0, 0);
            }
            
            _moveDirection = new Vector3(Input.GetAxis("Horizontal") * speed, _moveDirection.y, Input.GetAxis("Vertical") * speed);
            _moveDirection = transform.TransformDirection(_moveDirection);
            
            if (_controller.isGrounded)
            {
                if (Input.GetButton("Jump")) _moveDirection.y = jumpSpeed;
                else _moveDirection.y = 0;
            }

            _moveDirection.y -= gravity * Time.deltaTime;
            _controller.Move(_moveDirection * Time.deltaTime);
        }

        private void OnCollisionEnter(Collision collision)
        {
            LiveCount--;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("life"))
            {
                LiveCount += 2;
            }

            if (other.CompareTag("Finish"))
            {
                LiveCount = 9999999;
            }
        }
    }
}