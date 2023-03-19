using UnityEngine;

public class SpawnController : MonoBehaviour
{
    private Vector3 LastPoint = new Vector3(4.1f,-11.2f,93.59f);
    [SerializeField] private Transform[] _prefabs;
    [SerializeField] private Transform _prefabsGround;
    private Vector3 LastGroundPoint;
    private void Start()
    {
        LastGroundPoint = _prefabsGround.localPosition;
        for (int i = 0; i < 30; i++)
        {
            
            Vector3 newPoint =
                new Vector3(Random.Range(-8, 17), LastPoint.y, LastPoint.z + 28);
            
            var item = Instantiate(_prefabs[Random.Range(0,4)], transform.localPosition, Quaternion.identity);
            item.SetParent(transform);
            item.transform.localPosition = newPoint;
            LastPoint = newPoint;

        }
        for (int i = 0; i < 60; i++)
        {
            Vector3 newGroundPoint =
                new Vector3(LastGroundPoint.x, LastGroundPoint.y, LastGroundPoint.z+20f);
            
            var itemGround = Instantiate(_prefabsGround, transform.localPosition, Quaternion.identity);
            itemGround.SetParent(transform);
            itemGround.localPosition = newGroundPoint;
            LastGroundPoint = newGroundPoint;
        }
    }
}