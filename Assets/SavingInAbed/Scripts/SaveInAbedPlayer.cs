using System;
using UnityEngine;

namespace SavingInAbed.Scripts
{
    [RequireComponent(typeof(CharacterController))]
    public class SaveInAbedPlayer : MonoBehaviour
    {
        [SerializeField] private Transform[] _spawnPoints;

        public float walkingSpeed = 7.5f;
        public float runningSpeed = 11.5f;
        public float jumpSpeed = 8.0f;
        public float gravity = 20.0f;
        public Camera playerCamera;
        public float lookSpeed = 2.0f;
        public float lookXLimit = 45.0f;

        CharacterController characterController;
        Vector3 moveDirection = Vector3.zero;
        float rotationX = 0;

        [HideInInspector]
        public bool canMove = true;


        private void Start()
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            characterController = GetComponent<CharacterController>();
        }
        
        private void Movement()
        {
            Vector3 forward = transform.TransformDirection(Vector3.forward);
            Vector3 right = transform.TransformDirection(Vector3.right);
            bool isRunning = Input.GetKey(KeyCode.LeftShift);
            float curSpeedX = canMove ? (isRunning ? runningSpeed : walkingSpeed) * Input.GetAxis("Vertical") : 0;
            float curSpeedY = canMove ? (isRunning ? runningSpeed : walkingSpeed) * Input.GetAxis("Horizontal") : 0;
            float movementDirectionY = moveDirection.y;
            moveDirection = (forward * curSpeedX) + (right * curSpeedY);

            if (Input.GetButton("Jump") && canMove && characterController.isGrounded)
            {
                moveDirection.y = jumpSpeed;
            }
            else
            {
                moveDirection.y = movementDirectionY;
            }
            
            if (!characterController.isGrounded)
            {
                moveDirection.y -= gravity * Time.deltaTime;
            }

            characterController.Move(moveDirection * Time.deltaTime);

            if (canMove)
            {
                rotationX += -Input.GetAxis("Mouse Y") * lookSpeed;
                rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);
                playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
                transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeed, 0);
            }
        }

        private void Update()
        {
            if(Input.GetKeyDown(KeyCode.R))
                ResetPosition();
        
            Movement();
        }

        private void ResetPosition()
        {
            try
            {
                characterController.enabled = false;
                transform.position = LoadPosition();
                characterController.enabled = true;
            }
            catch (Exception e) { }
            
        }

        private void OnTriggerEnter(Collider other)
        {
            SavePosition(other.tag);
        }

        private void SavePosition(string tag)
        {
            int numericValue;
            if (!int.TryParse(tag,out numericValue))
                return;
            Debug.Log("Save pos");
            PlayerPrefs.SetInt("save_in_bed",numericValue);
            
        }

        private Vector3 LoadPosition()
        {
            var id = PlayerPrefs.GetInt("save_in_bed");
            return _spawnPoints[id - 1].position;
        }
    }
}