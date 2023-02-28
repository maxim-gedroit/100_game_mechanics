using System;
using System.Collections.Generic;
using UnityEngine;

public class PointController : MonoBehaviour
{
    
    private List<Vector3Int> _points = new List<Vector3Int>();
    private void Awake()
    {
        Point.OnClicekd += CreatePair;
    }

    private void CreatePair(Vector3Int pos)
    {
        _points.Add(pos);
    }

    public List<Vector3Int> GetPoints()
    {
        return _points;
    }

    private void OnDestroy()
    {
        Point.OnClicekd -= CreatePair;
    }
}