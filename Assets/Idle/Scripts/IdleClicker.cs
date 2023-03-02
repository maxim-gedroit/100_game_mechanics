using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

/*
 * For the video, I made a day change by the button,
 * but if you really need to make the cube grow while we are not playing,
 * then the first thing I would do is save the current date through the json utility along with the current value of the cube size,
 * and then at start games simply load this value and add the size factor to it.
 */

public class IdleClicker : MonoBehaviour
{
    [SerializeField] private Transform _object;
    [SerializeField] private Button _btn;
    [SerializeField] private TMP_Text _text;
    
    private int dayAfterStart;

    private void Awake()
    {
        _btn.onClick.AddListener(SizeSimulate);
    }

    private void Start()
    {
        _text.text = DateTime.Now.ToString();
    }

    private void SizeSimulate()
    {
        dayAfterStart++;
        _text.text = DateTime.Now.AddDays(dayAfterStart).ToString();
        _object.localScale += Vector3.one*0.1f;
    }
}