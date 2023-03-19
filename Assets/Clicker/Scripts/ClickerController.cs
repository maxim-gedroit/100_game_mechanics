using System;
using System.Collections;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class ClickerController : MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] private ClickerGun[] _clickerGuns;
    [SerializeField] private Transform _enemy;
    [SerializeField] private Transform _target;

    private void Awake()
    {
        _button.onClick.AddListener(() =>
        {
            foreach (var item in _clickerGuns)
            {
                item.Fire();
            }
        });
    }

    private void Start()
    {
        StartCoroutine(Spawn());
    }
    
    private IEnumerator Spawn()
    {
        while (true)
        {
            var pos = new Vector3(Random.Range(50, 122), 2, Random.Range(-616, -518));
            var item = Instantiate(_enemy, transform.position,Quaternion.identity);
            item.position = pos;
            item.GetComponent<ClickerEnemy>().Init(_target);
            item.localScale = Vector3.zero;
            item.DOScale(1, 0.3f);
            yield return new WaitForSeconds(0.08f);
        }
    }
}