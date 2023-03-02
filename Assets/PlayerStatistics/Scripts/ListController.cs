using DG.Tweening;
using UnityEngine;

public class ListController : MonoBehaviour
{
    [SerializeField] private RectTransform[] _listController;
    private float topY;
    private float middleY;
    private float bottomY;

    private void Start()
    {
        topY = -16f;
        middleY = -50f;
        bottomY = -83f;
    }

    public void ChangeUI(int index1,int index2,int index3)
    {
        _listController[index1].DOLocalMoveY(topY, 0.5f);
        _listController[index2].DOLocalMoveY(middleY, 0.5f);
        _listController[index3].DOLocalMoveY(bottomY, 0.5f);
    }
}
