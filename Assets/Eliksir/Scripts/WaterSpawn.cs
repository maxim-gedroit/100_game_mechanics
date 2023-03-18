using System.Collections;
using DG.Tweening;
using UnityEngine;

public class WaterSpawn : MonoBehaviour
{
    [SerializeField] private Transform _water;
    [SerializeField] private Transform _cup;
    private int count;
    private void Start()
    {
        StartCoroutine(Spawn());
        Invoke("RotateCup",10f);
        
        
    }

    private void RotateCup()
    {
        _cup.DOLocalRotate(new Vector3( _cup.localRotation.x+130f, 0f, 0f), 5f);
    }

    private IEnumerator Spawn()
    {
        while (count < 1000)
        {
            count++;
            var item = Instantiate(_water, new Vector3(
                Random.Range(transform.position.x,transform.position.x+0.3f),
                Random.Range(transform.position.y,transform.position.y+0.3f),
                Random.Range(transform.position.z,transform.position.z+0.3f)), 
                Quaternion.identity);
            item.SetParent(transform);
            yield return new WaitForSeconds(0.01f);
        }
    }
}
