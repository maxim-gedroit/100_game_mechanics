using System;
using DG.Tweening;
using TMPro;
using UnityEngine;

public class FarmCotroller : MonoBehaviour
{
    private int Coins;
    [SerializeField] private TMP_Text _text;

    private Ray ray;
    private RaycastHit hit;
    private void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 1000))
            {
                if (hit.collider.tag == "life")
                {
                    Coins++;
                    _text.text = "Coins: " + Coins.ToString();
                    hit.collider.gameObject.tag = "1";
                    hit.transform.DOScale(0, 0.2f);
                    Destroy(hit.collider.gameObject,1f);
                }
            }

            if (hit.collider.tag == "2")
            {
                if (Coins >= 10)
                {
                    Coins -= 10;
                    _text.text = "Coins: " + Coins.ToString();
                    hit.collider.transform.DOScale(hit.collider.transform.localScale * 1.5f, 0.3f);
                }
            }
        }
    }
}