using System;
using System.Collections.Generic;
using UnityEngine;

public class FlexibleWeaponController : MonoBehaviour
{
    public WeaponData _Data;
    [SerializeField] private Weapon _weapon;
    private List<string> wp = new List<string>();

    private void Update()
    {
        
        if (Input.GetButtonDown("Fire1"))
        {
            RaycastHit hit;
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit))
            {
                var id = hit.collider.tag;
                int numericValue;
                if (!int.TryParse(id,out numericValue))
                    return;
                
                if(!wp.Contains(id))
                    wp.Add(id);
                
                if (wp.Count == 3)
                {
                    string Id = String.Empty;
                    foreach (var item in wp)
                    {
                        Id += item;
                    }

                    foreach (var item in _Data._Datas)
                    {
                        if (item.Id == Id)
                        {
                            _weapon.Set(item.Weapon);
                        }
                        wp.Clear();
                    }
                }
            }
        }
    }
}