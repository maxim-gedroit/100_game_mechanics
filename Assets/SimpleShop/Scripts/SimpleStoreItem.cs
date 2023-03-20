using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SimpleStoreItem : MonoBehaviour
{
    public int count;
    public int price;
    
    [SerializeField] private TMP_Text _title;
    [SerializeField] private TMP_Text _label;
    [SerializeField] private Button _btn;

    private void Awake()
    {
        _btn.onClick.AddListener(Buy);
    }

    private void Start()
    {
        _title.text =$"${price}";
    }

    private void Buy()
    {
        SimpleStoreController.Money -= price;
        count++;
        _label.text =$"X{count}";
    }
}
