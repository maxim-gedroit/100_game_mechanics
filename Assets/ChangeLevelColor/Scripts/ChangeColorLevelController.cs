using System;
using UnityEngine;

public class ChangeColorLevelController : MonoBehaviour
{
    [SerializeField] private Shader _deffault;
    [SerializeField] private Shader _shadergrey;
    [SerializeField] private Shader _shaderinver;
    
    private bool _enableShader = true;
    private Material _material;

    private void Awake()
    {
        _material = new Material(_deffault);
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.G))
        {
            _enableShader = !_enableShader;
            _material = new Material(_shadergrey);
        }
        if (Input.GetKeyUp(KeyCode.I))
        {
            _enableShader = !_enableShader;
            _material = new Material(_shaderinver);
        }
    }
    
    private void OnRenderImage(RenderTexture src, RenderTexture dest)
    {
        if (_enableShader)
        {
            Graphics.Blit(src, dest, _material);
        }
        else
        {
            Graphics.Blit(src, dest);
        }

    }
    
}
