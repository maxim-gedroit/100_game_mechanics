using System;
using System.Collections;
using System.Linq;
using PathCreation;
using TMPro;
using UnityEngine;

public class TrackController : MonoBehaviour
{
    [SerializeField] private Car[] car;

    [SerializeField] private PathCreator _pathCreator;
    [SerializeField] private ListController _listController;
    [SerializeField] private TMP_Text[] _texts;


    private void Awake()
    {
        car[0].Init(_pathCreator,Vector3.zero);
        car[1].Init(_pathCreator,new Vector3(2,0,0));
        car[2].Init(_pathCreator, new Vector3(-2,0,0));
    }

    private void Start()
    {
        StartCoroutine(CheckDis());
    }
    
    private IEnumerator CheckDis()
    {
        while (true)
        {
            _texts[0].text = Math.Round(car[0].distance,1).ToString();
            _texts[1].text = Math.Round(car[1].distance,1).ToString();
            _texts[2].text = Math.Round(car[2].distance,1).ToString();
            var carNew = from i in car
                orderby i.distance descending
                select i;
            var arr = carNew.ToArray();
            
            _listController.ChangeUI(
                arr[0].ID,
                arr[1].ID,
                arr[2].ID);
            
            yield return new WaitForSeconds(1f);
        }
    }
}