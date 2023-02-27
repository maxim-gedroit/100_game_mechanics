using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lava : MonoBehaviour
{
    private void Update()
    {
        if (transform.position.y <= 48)
        {
            transform.Translate(Vector3.up * 0.001f);
        }
    }
}