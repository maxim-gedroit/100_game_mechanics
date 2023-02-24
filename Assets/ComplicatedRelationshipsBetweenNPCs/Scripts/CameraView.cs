using System;
using UnityEngine;

public class CameraView : MonoBehaviour
{
    public Transform target;
    
    private void Update()
    {
        LookRotationByQuatSmootly();
    }
    private void LookRotationByQuatSmootly()
    {
        float degreesPerSecond = 30 * Time.deltaTime;
        Vector3 direction = target.transform.position - transform.position;
        Quaternion targetRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, degreesPerSecond);
    }
}