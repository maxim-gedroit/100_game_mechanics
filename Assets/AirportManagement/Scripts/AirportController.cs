using System;
using System.Collections;
using PathCreation;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class AirportController : MonoBehaviour
{
    public static event Action<int> OnSelfDestruct;
    [SerializeField] private PathCreator _pathCreator;
    [SerializeField] private Transform[] _planes;
    [SerializeField] private Button _button;
    private int countPlane1;
    private int countPlane2;
    
    private void Awake()
    {
        _button.onClick.AddListener(Remanage);
    }
    

    private void Remanage()
    {
        CreatePlane(0);
        countPlane1++;

        if (countPlane1 > 8)
        {
            OnSelfDestruct?.Invoke(0);

            CreatePlane(1);
            countPlane1 = 0;
            countPlane2++;
        }

        if (countPlane2 > 2)
        {
            countPlane2 = 0;
            OnSelfDestruct?.Invoke(1);
            CreatePlane(2);
        }
    }

    private Plane CreatePlane(int index)
    {
        var planetr = Instantiate(_planes[index], transform.position, Quaternion.Euler(0,0,0));
        var plane = planetr.GetComponent<Plane>();
        plane.Init(_pathCreator);
        return plane;
    }
}
