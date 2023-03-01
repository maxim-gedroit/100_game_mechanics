using System;
using System.Collections;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class RythmBaseController : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;
    [SerializeField] private RectTransform[] _positions;
    [SerializeField] private RectTransform[] _prefabs;
    [SerializeField] private RectTransform _parent;

    private int _counter;
    private void Awake()
    {
        RythmButton.OnClicked += () =>
        {
            _counter++;
            _text.text = $"Score : {_counter}";
        };
    }

    private void Start()
    {
        StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        while (true)
        {
            var index = Random.Range(0, 4);
            var item = Instantiate(_prefabs[index], _positions[index].position, Quaternion.identity);
            item.SetParent(_parent);
            item.localScale = Vector3.one;
            Destroy(item.gameObject,4);
            
            yield return new WaitForSeconds(0.75f);
        }
    }
    
}