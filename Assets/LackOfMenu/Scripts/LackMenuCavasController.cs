using TMPro;
using UnityEngine;

public class LackMenuCavasController : MonoBehaviour
{
    public static LackMenuCavasController Instance;
    [SerializeField] private TMP_Text _text;
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public void UpdateUI(string str)
    {
        _text.text = str;
    }
}
