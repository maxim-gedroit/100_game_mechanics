using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Point : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private Color _activeColor;
    public static event Action<Vector3Int> OnClicekd;
    public Vector3Int PositionByXY;

    private Image _image;

    private void Awake()
    {
        _image = GetComponent<Image>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {

        _image.color = _activeColor;
        OnClicekd?.Invoke(PositionByXY);
    }
}
