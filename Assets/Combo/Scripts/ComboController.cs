using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ComboController : MonoBehaviour
{
    private Animator _animator;
    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            _animator.SetBool("Fight1",true);
            _animator.SetBool("Fight2",false);
            _animator.SetBool("Combo",false);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            _animator.SetBool("Fight1",false);
            _animator.SetBool("Fight2",true);
            _animator.SetBool("Combo",false);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            _animator.SetBool("Fight1",false);
            _animator.SetBool("Fight2",false);
            _animator.SetBool("Combo",true);
        }
    }
}
