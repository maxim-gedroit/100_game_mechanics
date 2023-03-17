using DG.Tweening;
using PathCreation;
using UnityEngine;

public class Plane : MonoBehaviour
{
    public int id;
    private float _speed = 15f;
    public float distance;
    private PathCreator _pathCreator;

    private void Awake()
    {
        AirportController.OnSelfDestruct += HidePlane;
    }

    public void Init(PathCreator pathCreator)
    {
        
        _pathCreator = pathCreator;
        transform.localScale = Vector3.zero;
        transform.DOScale(1f, 1f);
    }

    public void HidePlane(int index)
    {
        if (index != id)
            return;
        
        transform.DOScale(0f, 1f).OnComplete(() =>
        {
            Destroy(gameObject);
        });
        
    }

    private void Update()
    {
        distance += _speed * Time.deltaTime;
        transform.position = _pathCreator.path.GetPointAtDistance(distance);
        transform.rotation = _pathCreator.path.GetRotationAtDistance(distance);
    }

    private void OnDestroy()
    {
        AirportController.OnSelfDestruct -= HidePlane;
    }
}