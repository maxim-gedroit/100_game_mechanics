using UnityEngine;

public class LampShere : BaseObject
{
    [SerializeField] private GameObject _lamp;
    private void Start()
    {
        _lamp.SetActive(false);
    }
    
    public override void Connect(bool state)
    {
        base.Connect(state);
        _lamp.SetActive(state);
    }
}
