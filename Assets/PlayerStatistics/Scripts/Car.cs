using System.Collections;
using PathCreation;
using UnityEngine;
using Random = UnityEngine.Random;

public class Car : MonoBehaviour
{
    private PathCreator _pathCreator;
    public int ID;
    private float _speed = 15f;
    public float distance;
    private Vector3 _offset;

    private void Start()
    {
        StartCoroutine(ChangeSpeed());
    }

    private IEnumerator ChangeSpeed()
    {
        while (true)
        {
            _speed = Random.Range(10, 15);
            yield return new WaitForSeconds(1f);
        }
    }


    public void Init(PathCreator pathCreator, Vector3 offset)
    {
        _offset = offset;
        _pathCreator = pathCreator;
    }
    
    private void Update()
    {
        distance += _speed * Time.deltaTime;
        transform.position = _pathCreator.path.GetPointAtDistance(distance) + _offset;
        transform.rotation = _pathCreator.path.GetRotationAtDistance(distance);
    }
}
