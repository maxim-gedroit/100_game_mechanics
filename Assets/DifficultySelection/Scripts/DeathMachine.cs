using UnityEngine;

public class DeathMachine : MonoBehaviour
{
    [SerializeField] private Transform Disk;
    [SerializeField] private Transform DiskContainer;
    private float _speedRot;
    private float _speedTransform;
    private int dir;

    private void Awake()
    {
        DifficultySelectionController.OnDiff += SetStartSpeed;
    }

    private void SetStartSpeed(int k)
    {
        _speedRot = Random.Range(100 * k, 300 * k);
        _speedTransform = Random.Range(10 * k, 20 * k);
    }

    private void Update()
    {
        if (Disk.position.x <= -18f)
            dir = -1;
        
        if (Disk.position.x >= 23f)
            dir = 1;

        DiskContainer.Rotate(Vector3.forward * (Time.deltaTime * dir *_speedRot),Space.World);
        Disk.Translate(Vector3.left * (Time.deltaTime * dir * _speedTransform),Space.World);
    }
}