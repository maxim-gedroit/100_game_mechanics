using System;
using TMPro;
using UnityEngine;

public class SimpleStoreController : MonoBehaviour
{
    public static int Money = 9999999;
    [SerializeField] private TMP_Text _Title;

    private void Update()
    {
        _Title.text = Money.ToString();
    }
}
