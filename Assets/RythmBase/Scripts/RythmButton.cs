using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class RythmButton : MonoBehaviour
{
    public static event Action OnClicked; 
    public KeyCode _keyCode;
    
    private Image _image;
    private Sequence sequenceSize;
    private Sequence sequenceFade;
    private bool isClicked;

    private void Awake()
    {
        _image = GetComponent<Image>();
    }

    private void Update()
    {
        isClicked = false;
        if (Input.GetKey(_keyCode))
        {
            isClicked = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (isClicked)
        {
            OnClicked?.Invoke();
            PlayAnim();
        }

        
    }

    private void PlayAnim()
    {
        sequenceSize = DOTween.Sequence();
        sequenceFade = DOTween.Sequence();
        
        sequenceFade.Append(_image.DOFade(1, 0.2f));
        sequenceSize.Append(transform.DOPunchScale(Vector3.one * 0.2f, 0.5f, 1));
        sequenceFade.Append(_image.DOFade(0.5f, 0.2f));
        
        sequenceSize.Play();
        sequenceFade.Play();
    }
}