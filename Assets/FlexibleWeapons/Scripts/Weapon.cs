using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    private Transform _weaponTemp;
    public void Set(Transform weapon)
    {
        if (_weaponTemp != null)
            Destroy(_weaponTemp.gameObject);
        
        _weaponTemp = Instantiate(weapon, transform.position, transform.rotation);
        _weaponTemp.SetParent(transform);
    }
}
