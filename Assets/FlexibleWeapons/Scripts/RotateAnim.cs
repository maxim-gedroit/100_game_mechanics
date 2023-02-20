using UnityEngine;

public class RotateAnim : MonoBehaviour
{
    private void Update()
    {
        transform.Rotate(Vector3.up * 0.2f);
    }
}
