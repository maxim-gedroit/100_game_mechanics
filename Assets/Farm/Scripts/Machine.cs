using System.Collections;
using DG.Tweening;
using UnityEngine;
using Random = UnityEngine.Random;

public class Machine : MonoBehaviour
{
    [SerializeField] private Transform _prefab;
    [SerializeField] private Transform _target;

    private Sequence _sequence;

    private void Start()
    {
        StartCoroutine(Spawn());
       
    }

    private IEnumerator Spawn()
    {
        while (true)
        {
            _sequence = DOTween.Sequence();
            _sequence.Append(_target.DOLocalMoveY(0.3f,0.5f));
            _sequence.Append(_target.DOLocalMoveY(0.7f, 0.2f));
            _sequence.Play();

            _sequence.OnComplete(() =>
            {
                var obj = Instantiate(_prefab, _target.position,Quaternion.identity);
                obj.localScale /= 1.5f;
                var rb = obj.GetComponent<Rigidbody>();
                rb.AddForce(_target.up * 400f);
            });
            
            

            yield return new WaitForSeconds(Random.Range(1,3));
        }
    }
}