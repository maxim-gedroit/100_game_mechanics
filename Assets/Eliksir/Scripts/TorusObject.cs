using System;
using UnityEngine;

public class TorusObject : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        transform.localScale += new Vector3(.002f, .002f, .002f);
    }
}
