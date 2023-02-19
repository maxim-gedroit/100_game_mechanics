using System;
using UnityEngine;

namespace LackOfMenu.Scripts
{
    public class MenuItem : MonoBehaviour
    {
        [SerializeField] private String _name;
        private bool isClicked;
        private void OnCollisionEnter(Collision collision)
        {
            if(isClicked)
                return;
            
            LackMenuCavasController.Instance.UpdateUI(_name);
            isClicked = true;
        }
    }
}
