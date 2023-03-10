using System;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class UndoPlayerContrller : MonoBehaviour
{
    [SerializeField] private Button Undo;
    [SerializeField] private Button Redo;
    
    private RaycastHit hit;
    private Camera  _mainCamera;
    private int tempIndex;
    private List<Vector3> points = new List<Vector3>();
    

    private void Awake()
    {
        Undo.onClick.AddListener(() =>
        {
            if (tempIndex - 1 < 0)
            {
                MoveObjectU(points[0]);
                return;
            }
           
            tempIndex--;
            MoveObjectU(points[tempIndex]);

        });
       
        Redo.onClick.AddListener(() =>
        {
            if (tempIndex + 1 > points.Count)
            {
                MoveObject(points[points.Count]);
                return;
            }
            tempIndex++;
            MoveObject(points[tempIndex]);
        });
    }

    void Start()
    {
        _mainCamera = Camera.main;
        points.Add(transform.position);
        tempIndex = points.Count - 1;
        
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(_mainCamera.ScreenPointToRay(Input.mousePosition), out hit))
            {
               
                points.Add(hit.point);
                tempIndex = points.Count - 1;
                MoveObject(hit.point);
            }
        }
    }
    
    private void MoveObject(Vector3 point)
    {
        var seq = DOTween.Sequence();
        seq.Append(transform.DOMoveX(point.x, 1f));
        seq.Append(transform.DOMoveZ(point.z, 1f));
        seq.Play();
    }
    
    private void MoveObjectU(Vector3 point)
    {
        var seq = DOTween.Sequence();
        seq.Append(transform.DOMoveZ(point.z, 1f));
        seq.Append(transform.DOMoveX(point.x, 1f));
        seq.Play();
    }
}