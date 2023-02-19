using System;
using System.Numerics;
using UnityEngine;
using Quaternion = UnityEngine.Quaternion;
using Vector3 = UnityEngine.Vector3;

namespace LackOfMenu
{
    public class LackOfMenuPlayer : MonoBehaviour
    {
        [SerializeField] private Rigidbody _bullet;
        [SerializeField] private Transform _gun;

        public enum RotationAxes
        {
            MouseXAndY = 0, 
            MouseX = 1,
            MouseY = 2
        }
        public RotationAxes axes = RotationAxes.MouseXAndY;
        public float sensitivityX = 15F;
        public float sensitivityY = 15F;

        public float minimumX = -360F;
        public float maximumX = 360F;

        public float minimumY = -60F;
        public float maximumY = 60F;

        float rotationY = 0F;

        private void Update()
        {
            Shot();
            View();
        }

        private void Shot()
        {
            if (Input.GetMouseButtonDown(0))
            {
                Rigidbody bulletClone = (Rigidbody) Instantiate(_bullet, _gun.position, Quaternion.identity);
                bulletClone.AddForce(_gun.forward ,ForceMode.Impulse);
            }
        }

        private void View()
        {
            if (axes == RotationAxes.MouseXAndY)
            {
                float rotationX = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * sensitivityX;

                rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
                rotationY = Mathf.Clamp (rotationY, minimumY, maximumY);

                transform.localEulerAngles = new Vector3(-rotationY, rotationX, 0);
            }
            else if (axes == RotationAxes.MouseX)
            {
                transform.Rotate(0, Input.GetAxis("Mouse X") * sensitivityX, 0);
            }
            else
            {
                rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
                rotationY = Mathf.Clamp (rotationY, minimumY, maximumY);

                transform.localEulerAngles = new Vector3(-rotationY, transform.localEulerAngles.y, 0);
            }
        }
    }
}
