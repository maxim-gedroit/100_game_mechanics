using UnityEngine;

public class ClickerGun : MonoBehaviour
{
    [SerializeField] private Transform _bullet;

    public void Fire()
    {
        var item = Instantiate(_bullet, transform.position,Quaternion.identity);
        var rb = item.GetComponent<Rigidbody>();
        item.localScale = Vector3.one * 0.2f;
        rb.AddForce(transform.right * (-3000f));
    }
}