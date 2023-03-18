using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class WaterDrop : MonoBehaviour
{
    private bool OnDesableSelf;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Water") || collision.collider.CompareTag("Cup"))
            return;

        if (!OnDesableSelf)
        {
            OnDesableSelf = true;
            transform.DOScale(0, 0.2f).OnComplete(()=>
            {
                Destroy(gameObject);
            });
        }
    }
}
