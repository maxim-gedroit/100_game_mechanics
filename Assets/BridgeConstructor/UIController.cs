using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] private Rigidbody _sphere;
    [SerializeField] private Button _createBtn;
    [SerializeField] private PointController _pointController;
    [SerializeField] private BridgeConstructor _bridgeConstructor;

    private void Awake()
    {
        _createBtn.onClick.AddListener(OnCreateBtnClicked);
    }

    private void OnCreateBtnClicked()
    {
        var _points = _pointController.GetPoints();
        _sphere.isKinematic = false;
        _bridgeConstructor.CreateBridge(_points.ToArray());
    }

    private void OnDestroy()
    {
        _createBtn.onClick.RemoveListener(OnCreateBtnClicked);
    }
}
