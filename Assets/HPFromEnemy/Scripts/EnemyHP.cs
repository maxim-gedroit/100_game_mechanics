using DG.Tweening;
using UnityEngine;

public class EnemyHP : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        BikePlayer.Instance.SetLabel(BikePlayer.Instance.CountHp++);
        transform.DOScale(0, 0.5f).OnComplete(() =>
        {
            Destroy(gameObject);
        });
    }
}
