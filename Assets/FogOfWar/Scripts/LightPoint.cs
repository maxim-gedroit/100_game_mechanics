using System;
using UnityEngine;

public class LightPoint : MonoBehaviour
{
    private Light _light;

    [SerializeField] private Color _startColor;
    [SerializeField] private Color _endColor;

    private void Awake()
    {
        _light = GetComponent<Light>();
    }

    private void Start()
    {
        _light.color = _startColor;
    }

    private void OnTriggerEnter(Collider other)
    {
        _light.color = _endColor;
    }
   
}
