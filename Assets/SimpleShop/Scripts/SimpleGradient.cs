using System.Collections;
using UnityEngine;
public class SimpleGradient : MonoBehaviour
{
    public Material yourGradientMaterial;

    private float _colorIndexLeft = 1;
    private float _colorIndexRight;
    
    private float ColorIndexLeft
    {
        get => _colorIndexLeft;
        set => _colorIndexLeft = _colorIndexLeft >= 1 ? 0 : value;
    }
    
    private float ColorIndexRight
    {
        get => _colorIndexRight;
        set => _colorIndexRight = _colorIndexRight <= 0 ? 1 : value;
    }

    private void Start()
    {
        StartCoroutine(ChangeColor());
    }

    private IEnumerator ChangeColor()
    {
        while (true)
        {
            yourGradientMaterial.SetColor("_Color",Color.HSVToRGB(ColorIndexLeft += 0.0001f, 0.5f, 0.7f));
            yourGradientMaterial.SetColor("_Color2",Color.HSVToRGB(ColorIndexRight -= 0.0001f, 0.7f, 0.5f));
            yield return new WaitForSeconds(0.01f);
        }
    }
}