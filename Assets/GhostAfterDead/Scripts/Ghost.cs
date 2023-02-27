using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Ghost : MonoBehaviour
{
    private Renderer _renderer;
    private Rigidbody _rigidbody;
    private bool _fly;
    private float _speed = 0.7f;
    
    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _renderer = GetComponent<Renderer>();
        SetFade(0);
        
    }

    private void Start()
    {
        Invoke("ShowAnim", 2f);
    }

    private void ShowAnim()
    {
        StartCoroutine("Show");
    }

    private IEnumerator Show()
    {
        float temp = 0;
        float res = 0f;
        while (res != 0.9f)
        {
            res = Mathf.Lerp(0, 1, temp);
            SetFade(res);
            temp += 0.1f;
            
            yield return new WaitForSeconds(0.1f);
        }
    }

    private void SetFade(float value)
    {
        _renderer.sharedMaterial.SetFloat("_Alpha",value);
    }

    private void Update()
    {
        if (transform.position.y >= 4f)
        {
            _fly = false;
        }
        
        if (transform.position.y <= 3.5f)
        {
            _fly = true;
        }

        Vector3 velocity = _fly ? Vector3.up * _speed: -Vector3.up * _speed;
        _rigidbody.velocity = velocity;
        
    }
}